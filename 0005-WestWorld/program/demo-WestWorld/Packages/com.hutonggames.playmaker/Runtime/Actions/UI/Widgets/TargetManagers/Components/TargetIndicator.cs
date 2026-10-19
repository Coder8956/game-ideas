using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Attaches UI indicators (brackets, nameplates, health bars, etc.) to world-space targets.
    /// Uses an IndicatorPanel (RectTransform) as the UI space to place indicators into.
    /// Works with screen-space or world-space canvases.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Target Indicator")]
    [Icon(Strings.EditorIconsPath + "TargetIndicatorIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/target-managers/target-indicator/")]
    public sealed class TargetIndicator : BaseTargetManager
    {
        #region Public API

        [PublicAPI]
        public bool HideWhenOffscreen
        {
            get => _hideWhenOffscreen;
            set => _hideWhenOffscreen = value;
        }

        [PublicAPI]
        public Vector3 WorldOffset
        {
            get => _worldOffset;
            set => _worldOffset = value;
        }

        [PublicAPI]
        public bool ClampToPanel
        {
            get => _clampToPanel;
            set => _clampToPanel = value;
        }

        [PublicAPI]
        public bool SortByDistance
        {
            get => _sortByDistance;
            set => _sortByDistance = value;
        }
        
        
        #endregion
        
        [Tooltip("Hide indicators when the target is outside the camera frustum or behind the camera.")]
        [SerializeField]
        private bool _hideWhenOffscreen = true;

        [Tooltip("Optional world-space offset from the target position (e.g., above the head).")]
        [SerializeField]
        private Vector3 _worldOffset = new Vector3(0f, 1.5f, 0f);

        [Tooltip("If true, clamp indicators to stay inside the Indicator Panel's rect.")]
        [SerializeField]
        private bool _clampToPanel = false;

        [Tooltip("If true, nearer targets can be sorted to draw on top (implemented in BeforeLayout, if desired).")]
        [SerializeField]
        private bool _sortByDistance = false; // hook for your BeforeLayout sorting, if you want it

        protected override void BeforeLayout(Camera cam)
        {
            if (!_sortByDistance)
                return;

            var camPos = cam.transform.position;

            // Sort by squared distance so closer targets come last in the list,
            // meaning they get laid out later and appear on top (higher sibling index).
            _entries.Sort((a, b) =>
            {
                if (a.Target == null && b.Target == null) return 0;
                if (a.Target == null) return -1;
                if (b.Target == null) return 1;

                var da = (a.Target.position - camPos).sqrMagnitude;
                var db = (b.Target.position - camPos).sqrMagnitude;

                // We want farther first, nearer last → compare reversed:
                return db.CompareTo(da);
            });

            // Optionally force sibling order to match list order:
            for (int i = 0; i < _entries.Count; i++)
            {
                var rect = _entries[i].Rect;
                if (rect != null)
                {
                    rect.SetSiblingIndex(i);
                }
            }
        }
        
        /// <summary>
        /// Layout logic for a single entry. Called by BaseTargetManager in LateUpdate.
        /// </summary>
        protected override void LayoutEntry(ref Entry entry, Camera cam)
        {
            var target = entry.Target;
            var rect   = entry.Rect;
            var panel  = IndicatorPanel;

            if (target == null || rect == null || cam == null || panel == null)
                return;

            // World → viewport using the TargetCamera
            var worldPos    = target.position + _worldOffset;
            var viewportPos = cam.WorldToViewportPoint(worldPos);

            var isBehind = viewportPos.z < 0f;

            // Basic camera-frustum offscreen test
            var offscreen =
                isBehind ||
                viewportPos.x < 0f || viewportPos.x > 1f ||
                viewportPos.y < 0f || viewportPos.y > 1f;

            if (_hideWhenOffscreen && offscreen)
            {
                rect.gameObject.SetActive(false);
                return;
            }

            // If we don't hide when offscreen, we still want a position,
            // so we continue with the projected point.

            // Viewport → screen
            var screenPos = new Vector2(
                viewportPos.x * Screen.width,
                viewportPos.y * Screen.height
            );

            // Screen → panel local
            var canvas = panel.GetComponentInParent<Canvas>();
            var canvasCam = canvas != null && canvas.renderMode != RenderMode.ScreenSpaceOverlay
                ? canvas.worldCamera
                : null;

            if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    panel,
                    screenPos,
                    canvasCam,
                    out var localPoint))
            {
                rect.gameObject.SetActive(false);
                return;
            }

            // Optionally clamp to the bounds of the panel rect
            if (_clampToPanel)
            {
                var r = panel.rect;
                localPoint.x = Mathf.Clamp(localPoint.x, r.xMin, r.xMax);
                localPoint.y = Mathf.Clamp(localPoint.y, r.yMin, r.yMax);
            }

            rect.gameObject.SetActive(true);

            // Place indicator in panel local space
            var worldOnPanel   = panel.TransformPoint(localPoint);
            var parent         = IndicatorPanel != null ? IndicatorPanel : rect.transform.parent;
            var localToParent  = parent != null
                ? parent.InverseTransformPoint(worldOnPanel)
                : worldOnPanel;

            rect.SetParent(parent, false);
            rect.localPosition = localToParent;

            // Rotation is left to the prefab FSM / animation.
            // TargetIndicator is usually "billboard-ish" on the UI, so we don't
            // rotate by default here.
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            // Hide entries when disabled
            for (var i = 0; i < _entries.Count; i++)
            {
                var r = _entries[i].Rect;
                if (r != null)
                    r.gameObject.SetActive(false);
            }
        }

    }
}
