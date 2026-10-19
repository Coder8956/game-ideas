using HutongGames.PlayMaker.Actions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Drag-to-reorder interaction component. Works with any <see cref="IDataReorderTarget"/>.
    ///
    /// The target owns:
    /// - absolute index resolution
    /// - paging slice rules
    /// - insert/move semantics
    ///
    /// The dragger owns:
    /// - overlay dragging visual
    /// - placeholder
    /// - layout ignore + raycast disabling
    /// - insertion slot computation
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Data Reorder Dragger")]
    [Icon(Strings.EditorIconsPath + "DataRowSelectionIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-reorder-dragger/")]
    public sealed class DataReorderDragger : MonoBehaviour
    {
        [SerializeField, Tooltip("Component that implements IDataReorderTarget (e.g. DataTableWidget).")]
        private MonoBehaviour _target;

        [SerializeField, Tooltip("Cancel drag when Escape is pressed.")]
        private bool _cancelOnEscape = true;

        [SerializeField, Tooltip("Animate list rows when the drag placeholder changes slot.")]
        private bool _animatePlaceholderMoves = true;

        [SerializeField, Min(0f), Tooltip("Seconds for row movement while dragging the placeholder.")]
        private float _placeholderMoveDuration = 0.08f;

        private IDataReorderTarget Target => _target as IDataReorderTarget;

        // Drag state
        private bool _dragging;
        private int _pointerId = int.MinValue;

        private PointerEventData _lastPed;

        private GameObject _dragItemGo;
        private RectTransform _dragItemRect;

        private int _fromAbs = -1;
        private int _visibleStart;
        private int _visibleCount;

        private RectTransform _overlay;
        private Canvas _rootCanvas;
        private Vector2 _pointerOffset;

        // Placeholder
        private GameObject _placeholderGo;
        private LayoutElement _placeholderLe;

        // Temporary overrides on dragged row
        private CanvasGroup _dragCg;
        private bool _dragCgAdded;

        private LayoutElement _dragLe;
        private bool _dragLeAdded;

        // Optional "always restore original slot on cancel"
        private int _originalPlaceholderSibling = -1;

        private readonly Dictionary<RectTransform, Coroutine> _moveTweens = new();

        private void Reset() => AutoFindTarget();

#if UNITY_EDITOR
        private void OnValidate() => AutoFindTarget();
#endif

        private void AutoFindTarget()
        {
            // Respect an already-assigned valid target.
            if (_target != null && _target is IDataReorderTarget)
                return;

            // Find first compatible component on the same GameObject.
            var monos = GetComponents<MonoBehaviour>();
            for (int i = 0; i < monos.Length; i++)
            {
                if (monos[i] is IDataReorderTarget reorderTarget)
                {
                    _target = reorderTarget as MonoBehaviour;
                    return;
                }
            }
        }
        
        private void Update()
        {
            if (!_dragging) return;
            if (!_cancelOnEscape) return;

            if (InputShim.GetKeyDown(KeyCode.Escape))
                CancelInternal();
        }

        private void OnDisable()
        {
            // Safety: never leave an item parented under overlay.
            if (_dragging)
                CancelInternal();

            StopAllMoveTweens();
        }

        public bool TryHandleAction(in DataUIActionRequest req)
        {
            if (!isActiveAndEnabled)
                return false;

            switch (req.Command)
            {
                case DataUICommand.BeginDrag:   return Begin(req);
                case DataUICommand.DragUpdate:  return UpdateDrag(req);
                case DataUICommand.EndDrag:     return End(req);
                case DataUICommand.CancelDrag:  return Cancel(req);
            }

            return false;
        }

        private bool Begin(in DataUIActionRequest req)
        {
            if (_dragging)
                return false;

            var t = Target;
            if (t == null || t.Content == null)
                return false;

            if (req.ItemGameObject == null)
                return false;

            var ped = req.Payload as PointerEventData;
            _pointerId = ped != null ? ped.pointerId : int.MinValue;
            _lastPed = ped;

            if (!t.TryBeginReorder(req.ItemGameObject, req.Payload, out _fromAbs, out _visibleStart, out _visibleCount))
                return false;

            _dragItemGo = req.ItemGameObject;
            _dragItemRect = _dragItemGo.transform as RectTransform;
            if (_dragItemRect == null)
                return false;

            EnsureRootCanvas();
            EnsureOverlay();

            CreatePlaceholder(t.Content, _dragItemRect);
            _originalPlaceholderSibling = _placeholderGo != null ? _placeholderGo.transform.GetSiblingIndex() : -1;

            TakeRowOutOfLayout(_dragItemGo);
            DisableRowRaycasts(_dragItemGo);

            // Reparent row to overlay
            _dragItemRect.SetParent(_overlay, worldPositionStays: true);
            _dragItemRect.SetAsLastSibling();

            // Pointer offset (so we don't snap pivot to cursor)
            if (ped != null && RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _overlay, ped.position, ped.pressEventCamera, out var local))
            {
                _pointerOffset = local - (Vector2)_dragItemRect.localPosition;
            }
            else
            {
                _pointerOffset = Vector2.zero;
            }

            _dragging = true;
            return true;
        }

        private bool UpdateDrag(in DataUIActionRequest req)
        {
            if (!_dragging)
                return false;

            var ped = req.Payload as PointerEventData;
            if (ped == null)
                return false;

            if (_pointerId != int.MinValue && ped.pointerId != _pointerId)
                return false;

            _lastPed = ped;

            UpdateDraggedVisual(ped);
            UpdatePlaceholder(Target.Content, ped);

            return true;
        }

        private bool End(in DataUIActionRequest req)
        {
            if (!_dragging)
                return false;

            var ped = req.Payload as PointerEventData;
            if (ped != null && _pointerId != int.MinValue && ped.pointerId != _pointerId)
                return false;

            var t = Target;
            if (t == null)
            {
                Cleanup(snapToPlaceholder: true, restoreOriginalOnCancel: false);
                return false;
            }

            // Ensure placeholder is at final slot.
            UpdatePlaceholder(t.Content, _lastPed);

            int insertionVisible;
            if (_placeholderGo != null)
            {
                insertionVisible = _placeholderGo.transform.GetSiblingIndex();

                // While dragging, content contains (visibleCount - 1) non-drag rows + placeholder.
                // If placeholder is last sibling, that represents "insert after the last visible row".
                var content = t.Content;
                if (content != null && insertionVisible == content.childCount - 1)
                    insertionVisible = _visibleCount;
            }
            else
            {
                insertionVisible = _visibleCount;
            }

            insertionVisible = Mathf.Clamp(insertionVisible, 0, Mathf.Max(0, _visibleCount));

            int insertBeforeAbs = _visibleStart + insertionVisible;

            bool moved = t.TryInsertAbsolute(_fromAbs, insertBeforeAbs);

            if (moved && _dragItemGo != null && t is DataTableWidget tableWidget)
                tableWidget.SuppressNextReorderAnimationForItem(_dragItemGo);

            // Snap into layout immediately at placeholder slot (feels good), then target rebuilds.
            Cleanup(snapToPlaceholder: true, restoreOriginalOnCancel: false);
            t.RequestRebuild();

            return moved;
        }

        private bool Cancel(in DataUIActionRequest req)
        {
            if (!_dragging)
                return false;

            var ped = req.Payload as PointerEventData;
            if (ped != null && _pointerId != int.MinValue && ped.pointerId != _pointerId)
                return false;

            CancelInternal();
            return true;
        }

        private void CancelInternal()
        {
            var t = Target;

            // Always restore the original slot on cancel.
            Cleanup(snapToPlaceholder: false, restoreOriginalOnCancel: true);

            t?.RequestRebuild();
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // Placeholder + insertion math
        // ─────────────────────────────────────────────────────────────────────────────

        private void CreatePlaceholder(RectTransform content, RectTransform row)
        {
            DestroyPlaceholder();

            _placeholderGo = new GameObject("DragPlaceholder", typeof(RectTransform), typeof(LayoutElement));
            var rt = (RectTransform)_placeholderGo.transform;
            rt.SetParent(content, worldPositionStays: false);

            // Stretch horizontally, fixed height.
            rt.anchorMin = new Vector2(0f, 1f);
            rt.anchorMax = new Vector2(1f, 1f);
            rt.pivot = new Vector2(0.5f, 1f);
            rt.localScale = Vector3.one;

            float h = row.rect.height;
            if (!(h > 0f) || float.IsNaN(h) || float.IsInfinity(h))
                h = 30f;

            // ✅ Critical: works even when VerticalLayoutGroup.ChildControlHeight is OFF
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, h);

            _placeholderLe = _placeholderGo.GetComponent<LayoutElement>();
            _placeholderLe.minHeight = h;
            _placeholderLe.preferredHeight = h;
            _placeholderLe.flexibleHeight = 0f;

            // Put placeholder where the row was (while it was still under content).
            _placeholderGo.transform.SetSiblingIndex(row.GetSiblingIndex());
        }

        private void UpdatePlaceholder(RectTransform content, PointerEventData ped)
        {
            if (_placeholderGo == null || content == null)
                return;

            int insertion = ComputeInsertionIndex(content, ped);

            // During drag, content children = non-drag rows + placeholder (dragged row is in overlay)
            int maxSibling = Mathf.Max(0, content.childCount - 1);
            insertion = Mathf.Clamp(insertion, 0, maxSibling);

            int current = _placeholderGo.transform.GetSiblingIndex();
            if (current == insertion)
                return;

            MovePlaceholder(content, insertion);
        }

        private void MovePlaceholder(RectTransform content, int toSibling)
        {
            if (_placeholderGo == null || content == null)
                return;

            if (!_animatePlaceholderMoves || _placeholderMoveDuration <= 0f)
            {
                _placeholderGo.transform.SetSiblingIndex(toSibling);
                return;
            }

            var before = CaptureChildPositions(content);

            _placeholderGo.transform.SetSiblingIndex(toSibling);

            Canvas.ForceUpdateCanvases();
            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
            Canvas.ForceUpdateCanvases();

            AnimateRowsToCurrentLayout(content, before);
        }

        private int ComputeInsertionIndex(RectTransform content, PointerEventData ped)
        {
            int nonDragRows = Mathf.Max(0, content.childCount - 1);

            Vector2 screen = ped?.position ?? InputShim.GetMousePosition();

            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    content, screen, ped?.pressEventCamera, out var local))
                return -1;

            int insertion = 0;

            for (int i = 0; i < content.childCount; i++)
            {
                var child = content.GetChild(i);
                if (child == null) continue;
                if (child.gameObject == _placeholderGo) continue;

                var rt = child as RectTransform;
                if (rt == null) continue;

                var worldMid = rt.TransformPoint(new Vector3(rt.rect.center.x, rt.rect.center.y, 0f));
                var mid = (Vector2)content.InverseTransformPoint(worldMid);

                // Higher local.y is above in a top-anchored list.
                if (local.y > mid.y)
                    return insertion;

                insertion++;
                if (insertion >= nonDragRows)
                    break;
            }

            return nonDragRows; // after last item
        }

        private void UpdateDraggedVisual(PointerEventData ped)
        {
            if (_dragItemRect == null || _overlay == null)
                return;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    _overlay, ped.position, ped.pressEventCamera, out var local))
            {
                _dragItemRect.localPosition = local - _pointerOffset;
            }
        }

        private Dictionary<RectTransform, Vector2> CaptureChildPositions(RectTransform content)
        {
            var positions = new Dictionary<RectTransform, Vector2>();

            for (int i = 0; i < content.childCount; i++)
            {
                var child = content.GetChild(i) as RectTransform;
                if (child == null)
                    continue;
                if (_placeholderGo != null && child.gameObject == _placeholderGo)
                    continue;

                positions[child] = child.anchoredPosition;
            }

            return positions;
        }

        private void AnimateRowsToCurrentLayout(RectTransform content, Dictionary<RectTransform, Vector2> before)
        {
            if (content == null || before == null || before.Count == 0)
                return;

            for (int i = 0; i < content.childCount; i++)
            {
                var child = content.GetChild(i) as RectTransform;
                if (child == null)
                    continue;
                if (_placeholderGo != null && child.gameObject == _placeholderGo)
                    continue;
                if (!before.TryGetValue(child, out var from))
                    continue;

                var to = child.anchoredPosition;
                if (from == to)
                    continue;

                StartOrRestartMoveTween(child, from, to);
            }
        }

        private void StartOrRestartMoveTween(RectTransform row, Vector2 from, Vector2 to)
        {
            if (row == null)
                return;

            if (_moveTweens.TryGetValue(row, out var running) && running != null)
            {
                StopCoroutine(running);
                _moveTweens.Remove(row);
            }

            var tween = StartCoroutine(AnimateRowMove(row, from, to));
            _moveTweens[row] = tween;
        }

        private System.Collections.IEnumerator AnimateRowMove(RectTransform row, Vector2 from, Vector2 to)
        {
            if (row == null)
                yield break;

            float duration = Mathf.Max(0.0001f, _placeholderMoveDuration);
            float t = 0f;
            row.anchoredPosition = from;

            while (t < duration)
            {
                t += Time.unscaledDeltaTime;
                float k = Mathf.Clamp01(t / duration);
                row.anchoredPosition = Vector2.LerpUnclamped(from, to, k);
                yield return null;
            }

            row.anchoredPosition = to;

            if (_moveTweens.TryGetValue(row, out var me) && me != null)
                _moveTweens.Remove(row);
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // Cleanup + temp overrides
        // ─────────────────────────────────────────────────────────────────────────────

        private void Cleanup(bool snapToPlaceholder, bool restoreOriginalOnCancel)
        {
            var t = Target;
            var content = t?.Content;

            StopAllMoveTweens();

            int placeholderSibling = _placeholderGo != null ? _placeholderGo.transform.GetSiblingIndex() : -1;
            var placeholderRect = _placeholderGo != null ? _placeholderGo.transform as RectTransform : null;

            if (_dragItemRect != null && content != null)
            {
                _dragItemRect.SetParent(content, worldPositionStays: false);

                if (restoreOriginalOnCancel && _originalPlaceholderSibling >= 0)
                {
                    _dragItemRect.SetSiblingIndex(_originalPlaceholderSibling);
                }
                else if (snapToPlaceholder && placeholderSibling >= 0)
                {
                    _dragItemRect.SetSiblingIndex(placeholderSibling);
                }

                // Keep drop start deterministic: align the restored row with the placeholder position
                // before the widget captures previous positions for reorder tweening.
                if (snapToPlaceholder && placeholderRect != null)
                    _dragItemRect.anchoredPosition = placeholderRect.anchoredPosition;

                RestoreRowToLayout();
                RestoreRowRaycasts();
            }

            DestroyPlaceholder();

            _dragging = false;
            _pointerId = int.MinValue;
            _lastPed = null;

            _dragItemGo = null;
            _dragItemRect = null;

            _fromAbs = -1;
            _visibleStart = 0;
            _visibleCount = 0;
            _pointerOffset = default;

            _originalPlaceholderSibling = -1;
        }

        private void StopAllMoveTweens()
        {
            foreach (var pair in _moveTweens)
            {
                if (pair.Value != null)
                    StopCoroutine(pair.Value);
            }

            _moveTweens.Clear();
        }

        private void DestroyPlaceholder()
        {
            if (_placeholderGo != null)
                Destroy(_placeholderGo);

            _placeholderGo = null;
            _placeholderLe = null;
        }

        private void TakeRowOutOfLayout(GameObject rowGo)
        {
            _dragLe = rowGo.GetComponent<LayoutElement>();
            _dragLeAdded = false;

            if (_dragLe == null)
            {
                _dragLe = rowGo.AddComponent<LayoutElement>();
                _dragLeAdded = true;
            }

            _dragLe.ignoreLayout = true;
        }

        private void RestoreRowToLayout()
        {
            if (_dragLe != null)
            {
                _dragLe.ignoreLayout = false;

                if (_dragLeAdded)
                    Destroy(_dragLe);
            }

            _dragLe = null;
            _dragLeAdded = false;
        }

        private void DisableRowRaycasts(GameObject rowGo)
        {
            _dragCg = rowGo.GetComponent<CanvasGroup>();
            _dragCgAdded = false;

            if (_dragCg == null)
            {
                _dragCg = rowGo.AddComponent<CanvasGroup>();
                _dragCgAdded = true;
            }

            _dragCg.blocksRaycasts = false;
        }

        private void RestoreRowRaycasts()
        {
            if (_dragCg != null)
            {
                _dragCg.blocksRaycasts = true;

                if (_dragCgAdded)
                    Destroy(_dragCg);
            }

            _dragCg = null;
            _dragCgAdded = false;
        }

        // ─────────────────────────────────────────────────────────────────────────────
        // Canvas / overlay
        // ─────────────────────────────────────────────────────────────────────────────

        private void EnsureRootCanvas()
        {
            if (_rootCanvas != null)
                return;

            _rootCanvas = GetComponentInParent<Canvas>();
            if (_rootCanvas == null)
#if UNITY_6000_4_OR_NEWER
                _rootCanvas = FindAnyObjectByType<Canvas>();
#else
                _rootCanvas = FindFirstObjectByType<Canvas>();
#endif

            if (_rootCanvas != null && !_rootCanvas.isRootCanvas)
                _rootCanvas = _rootCanvas.rootCanvas;
        }

        private void EnsureOverlay()
        {
            if (_rootCanvas == null) return;
            if (_overlay != null) return;

            var go = new GameObject("DragOverlay", typeof(RectTransform));
            _overlay = (RectTransform)go.transform;
            _overlay.SetParent(_rootCanvas.transform, worldPositionStays: false);
            _overlay.anchorMin = Vector2.zero;
            _overlay.anchorMax = Vector2.one;
            _overlay.offsetMin = Vector2.zero;
            _overlay.offsetMax = Vector2.zero;
            _overlay.SetAsLastSibling();
        }
    }
}
