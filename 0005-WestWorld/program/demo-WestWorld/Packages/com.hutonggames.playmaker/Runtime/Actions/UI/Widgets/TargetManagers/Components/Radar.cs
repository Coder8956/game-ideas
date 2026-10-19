using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// 2D radar widget that shows world-space targets as blips on a UI panel.
    /// Uses the IndicatorPanel (RectTransform) as the radar surface, which can be
    /// screen-space or world-space (e.g., cockpit HUD).
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Radar")]
    [Icon(Strings.EditorIconsPath + "RadarIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/target-managers/radar/")]
    public sealed class Radar : BaseTargetManager
    {
        public enum RadarPlane
        {
            XZ, // Typical 3D: X (left/right), Z (forward/back)
            XY  // 2D top-down or custom: X (left/right), Y (up/down)
        }

        public enum RadarMapping
        {
            Circular,    // radial mapping, clamped to a circle
            Rectangular  // linear mapping, fills the panel rect
        }
        
        #region PublicAPI
        
        [PublicAPI]
        public Transform Origin
        {
            get => _origin;
            set => _origin = value;
        }

        [PublicAPI]
        public RadarPlane Plane
        {
            get => _plane;
            set => _plane = value;
        }

        [PublicAPI]
        public RadarMapping Mapping
        {
            get => _mapping;
            set => _mapping = value;
        }

        [PublicAPI]
        public float MaxRange
        {
            get => _maxRange;
            set => _maxRange = value;
        }

        [PublicAPI]
        public bool HideBeyondRange
        {
            get => _hideBeyondRange;
            set => _hideBeyondRange = value;
        }

        [PublicAPI]
        public bool RotateWithOrigin
        {
            get => _rotateWithOrigin;
            set => _rotateWithOrigin = value;
        }

        #endregion

        // Private Fields
        
        [Tooltip("Origin transform used as the center of the radar (e.g., player, ship). If null, falls back to the camera transform.")]
        [SerializeField]
        private Transform _origin;

        [Tooltip("Which plane of world-space the radar projects onto.")]
        [SerializeField]
        private RadarPlane _plane = RadarPlane.XZ;

        [Tooltip("How world offsets are mapped onto the Indicator Panel.")]
        [SerializeField]
        private RadarMapping _mapping = RadarMapping.Circular;

        [Tooltip("World-space radius of the radar in units. Normalized radar coordinates are offset / Max Range.")]
        [SerializeField]
        private float _maxRange = 50f;

        [Tooltip("If true, targets beyond Max Range are hidden instead of clamped to the edge of the radar.")]
        [SerializeField]
        private bool _hideBeyondRange = false;

        [Tooltip("If true, the radar rotates with the Origin (so 'forward' is always up). If false, radar is world-aligned.")]
        [SerializeField]
        private bool _rotateWithOrigin = true;

        /// <summary>
        /// Layout logic for a single entry. Called by BaseTargetManager in LateUpdate.
        /// </summary>
        protected override void LayoutEntry(ref Entry entry, Camera cam)
        {
            var target = entry.Target;
            var rect   = entry.Rect;
            var panel  = IndicatorPanel;

            // We don't require a Camera to lay out the radar.
            if (target == null || rect == null || panel == null)
                return;

            // Choose origin:
            //  - Prefer explicit Origin
            //  - Otherwise fall back to the camera's transform if provided
            var origin = _origin != null ? _origin : (cam != null ? cam.transform : null);
            if (origin == null)
            {
                // No origin to measure offsets from → nothing to do
                rect.gameObject.SetActive(false);
                return;
            }

            // --- Compute 2D offset in radar space (XZ or XY, optionally rotated) ---

            var worldOffset = target.position - origin.position;

            Vector2 radarOffset;

            switch (_plane)
            {
                case RadarPlane.XY:
                {
                    var v = _rotateWithOrigin
                        ? origin.InverseTransformDirection(worldOffset)
                        : worldOffset;

                    radarOffset = new Vector2(v.x, v.y);
                    break;
                }

                case RadarPlane.XZ:
                default:
                {
                    var v = _rotateWithOrigin
                        ? origin.InverseTransformDirection(worldOffset)
                        : worldOffset;

                    radarOffset = new Vector2(v.x, v.z);
                    break;
                }
            }

            // --- Normalize by a single world range ---

            var range = Mathf.Max(_maxRange, 0.0001f);
            var normalized = radarOffset / range;

            bool outOfRange = false;

            if (_mapping == RadarMapping.Circular)
            {
                var dist = normalized.magnitude;
                if (dist > 1f)
                {
                    outOfRange = true;
                    normalized /= Mathf.Max(dist, 0.0001f); // clamp to unit circle
                }
            }
            else // Rectangular
            {
                if (Mathf.Abs(normalized.x) > 1f || Mathf.Abs(normalized.y) > 1f)
                    outOfRange = true;

                normalized.x = Mathf.Clamp(normalized.x, -1f, 1f);
                normalized.y = Mathf.Clamp(normalized.y, -1f, 1f);
            }

            if (_hideBeyondRange && outOfRange)
            {
                rect.gameObject.SetActive(false);
                return;
            }

            // --- Map normalized (-1..1) into IndicatorPanel rect ---

            var bounds = panel.rect;
            var center = bounds.center;
            var halfW  = bounds.width  * 0.5f;
            var halfH  = bounds.height * 0.5f;

            Vector2 localPoint;

            if (_mapping == RadarMapping.Circular)
            {
                var radius = Mathf.Min(halfW, halfH);
                localPoint = center + normalized * radius;
            }
            else // Rectangular
            {
                localPoint = new Vector2(
                    center.x + normalized.x * halfW,
                    center.y + normalized.y * halfH
                );
            }

            // Panel-local → parent local
            var worldOnPanel  = panel.TransformPoint(localPoint);
            var parent        = IndicatorPanel != null ? IndicatorPanel : rect.transform.parent;
            var localToParent = parent != null
                ? parent.InverseTransformPoint(worldOnPanel)
                : worldOnPanel;

            rect.SetParent(parent, false);
            rect.localPosition = localToParent;
            rect.gameObject.SetActive(true);
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
