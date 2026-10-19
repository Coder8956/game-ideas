using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Manages offscreen indicators for world-space targets.
    /// Spawns indicator prefabs and constrains their RectTransforms
    /// to the border of a bounds RectTransform (rectangle or circle).
    /// The prefabs themselves define all styling and extra behaviour.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Offscreen Indicator")]
    [Icon(Strings.EditorIconsPath + "OffscreenIndicatorIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/target-managers/offscreen-indicator/")]
    public sealed class OffscreenIndicator : BaseTargetManager
    {
        public enum BorderShape
        {
            Rectangle,
            Oval
        }
        
        #region PublicAPI

        [PublicAPI]
        public BorderShape Shape
        {
            get => _borderShape;
            set => _borderShape = value;
        }

        [PublicAPI]
        public bool HideWhenInsideBounds
        {
            get => _hideWhenInsideBounds;
            set => _hideWhenInsideBounds = value;
        }

        [PublicAPI]
        public bool RotateIndicators
        {
            get => _rotateIndicators;
            set => _rotateIndicators = value;
        }
        
        #endregion

        [Tooltip("Shape of the border indicators are clamped to.")]
        [SerializeField]
        private BorderShape _borderShape = BorderShape.Rectangle;

        [Tooltip("Hide indicators while the target is inside the bounds area.")]
        [SerializeField]
        private bool _hideWhenInsideBounds = true;

        [Tooltip("If true, rotates indicators to face outward along the border.")]
        [SerializeField]
        private bool _rotateIndicators = true;

        /// <summary>
        /// Layout logic for a single entry. Called by BaseTargetManager in LateUpdate.
        /// </summary>
    protected override void LayoutEntry(ref Entry entry, Camera cam)
    {
        var target = entry.Target;
        var rect   = entry.Rect;

        if (target == null || rect == null || cam == null || IndicatorPanel == null)
            return;

        var panel = IndicatorPanel;

        // --- World → viewport (for onscreen/offscreen test) ---

        var worldPos    = target.position;
        var viewportPos = cam.WorldToViewportPoint(worldPos);

        var isBehindOriginal = viewportPos.z < 0f;

        // "Onscreen" is defined purely in camera viewport space,
        // before any mirroring or panel logic:
        var isOnscreen =
            viewportPos.z > 0f &&
            viewportPos.x > 0f && viewportPos.x < 1f &&
            viewportPos.y > 0f && viewportPos.y < 1f;

        // If we hide inside bounds, and the target is onscreen, just hide
        // the indicator and bail out. Behind targets are always considered
        // "offscreen" for this purpose.
        if (_hideWhenInsideBounds && isOnscreen)
        {
            rect.gameObject.SetActive(false);
            return;
        }

        // --- For arrow placement, mirror behind targets so we keep a usable direction ---

        if (isBehindOriginal)
        {
            viewportPos.x = 1f - viewportPos.x;
            viewportPos.y = 1f - viewportPos.y;
            viewportPos.z = -viewportPos.z;
        }

        // --- Viewport → screen ---

        var screenPos = new Vector2(
            viewportPos.x * Screen.width,
            viewportPos.y * Screen.height
        );

        // --- Screen → panel local ---

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

        var bounds = panel.rect;
        var center = bounds.center;

        rect.gameObject.SetActive(true);

        // --- Direction from center towards point in panel local space ---

        var dir = localPoint - center;
        if (dir.sqrMagnitude < 0.0001f)
            dir = Vector2.up;
        dir.Normalize();

        // --- Clamp to border shape ---

        Vector2 edgeLocal;

        switch (_borderShape)
        {
            case BorderShape.Rectangle:
            default:
            {
                var halfW = bounds.width  * 0.5f;
                var halfH = bounds.height * 0.5f;

                var dx = dir.x;
                var dy = dir.y;

                var tx = dx != 0 ? halfW / Mathf.Abs(dx) : float.MaxValue;
                var ty = dy != 0 ? halfH / Mathf.Abs(dy) : float.MaxValue;

                var t = Mathf.Min(tx, ty);
                edgeLocal = center + dir * t;
                break;
            }

            case BorderShape.Oval:
            {
                // Proper ellipse intersection: (x/rx)^2 + (y/ry)^2 = 1
                var rx = Mathf.Max(bounds.width  * 0.5f, 0.0001f);
                var ry = Mathf.Max(bounds.height * 0.5f, 0.0001f);

                var dx = dir.x;
                var dy = dir.y;

                var denom = (dx * dx) / (rx * rx) + (dy * dy) / (ry * ry);
                if (denom < 1e-6f) denom = 1e-6f;

                var t = 1f / Mathf.Sqrt(denom);
                var ellipseOffset = dir * t;

                edgeLocal = center + ellipseOffset;
                break;
            }
        }

        // --- Panel local → parent local ---

        var worldEdge = panel.TransformPoint(edgeLocal);
        var parent    = IndicatorPanel != null ? IndicatorPanel : rect.transform.parent;

        var localToParent = parent != null
            ? parent.InverseTransformPoint(worldEdge)
            : worldEdge;

        rect.SetParent(parent, false);
        rect.localPosition = localToParent;

        if (_rotateIndicators)
        {
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            rect.localRotation = Quaternion.Euler(0f, 0f, angle - 90f); // assumes arrow graphic points up
        }
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
