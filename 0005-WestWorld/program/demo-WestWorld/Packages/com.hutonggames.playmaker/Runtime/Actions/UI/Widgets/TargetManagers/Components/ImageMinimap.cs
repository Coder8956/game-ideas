using System;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Displays a pre-rendered image or RenderTexture as a minimap and places tracked targets as blips in the same space.
    /// Maps world positions into the minimap using configurable world bounds.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Image Minimap")]
    [Icon(Strings.EditorIconsPath + "RadarIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/target-managers/")]
    public sealed class ImageMinimap : BaseTargetManager
    {
        public enum ImageMinimapPlane
        {
            XY,
            XZ
        }

        #region PublicAPI

        [PublicAPI]
        public RawImage MapImage
        {
            get => _mapImage;
            set => _mapImage = value;
        }

        [PublicAPI]
        public RectTransform ContentRoot
        {
            get => _contentRoot;
            set => _contentRoot = value;
        }

        [PublicAPI]
        public Transform Origin
        {
            get => _origin;
            set => _origin = value;
        }

        [PublicAPI]
        public bool RotateWithOrigin
        {
            get => _rotateWithOrigin;
            set => _rotateWithOrigin = value;
        }

        [PublicAPI]
        public bool HideOutsideMap
        {
            get => _hideOutsideMap;
            set => _hideOutsideMap = value;
        }

        [PublicAPI]
        public Transform FollowTarget
        {
            get => _followTarget;
            set => _followTarget = value;
        }

        [PublicAPI]
        public float MapScale
        {
            get => _mapScale;
            set => _mapScale = Mathf.Max(1f, value);
        }

        [PublicAPI]
        public Vector2 WorldMin
        {
            get => _worldMin;
            set => _worldMin = value;
        }

        [PublicAPI]
        public Vector2 WorldMax
        {
            get => _worldMax;
            set => _worldMax = value;
        }

        [PublicAPI]
        public ImageMinimapPlane Plane
        {
            get => _plane;
            set => _plane = value;
        }

        public override RectTransform IndicatorPanel
        {
            get => _contentRoot != null ? _contentRoot : base.IndicatorPanel;
            set => base.IndicatorPanel = value;
        }

        #endregion

        [Tooltip("RawImage that displays the minimap source image or RenderTexture.")]
        [SerializeField]
        private RawImage _mapImage;

        [Tooltip("Optional content root used for both the map image and spawned blips. Defaults to Indicator Panel.")]
        [SerializeField]
        private RectTransform _contentRoot;

        [Tooltip("Optional transform used to rotate the minimap so the player/up-vector stays aligned.")]
        [SerializeField]
        private Transform _origin;

        [Tooltip("If true, rotates the minimap content using Origin's Z rotation.")]
        [SerializeField]
        private bool _rotateWithOrigin;

        [Tooltip("Hide blips when their projected world position lies outside the configured world bounds.")]
        [SerializeField]
        private bool _hideOutsideMap = true;

        [Tooltip("Optional target used to center the visible minimap window.")]
        [SerializeField]
        private Transform _followTarget;

        [Tooltip("Zoom level for the visible map window. 1 shows the full map, 2 shows half-width/half-height, etc.")]
        [SerializeField]
        private float _mapScale = 1f;

        [Tooltip("Lower-left world-space point mapped to the minimap image.")]
        [SerializeField]
        private Vector2 _worldMin = new Vector2(-50f, -50f);

        [Tooltip("Upper-right world-space point mapped to the minimap image.")]
        [SerializeField]
        private Vector2 _worldMax = new Vector2(50f, 50f);

        [Tooltip("Which world-space plane is mapped into the minimap.")]
        [SerializeField]
        private ImageMinimapPlane _plane = ImageMinimapPlane.XY;

        [NonSerialized]
        private bool _hasLastFollowPosition;

        [NonSerialized]
        private Vector2 _lastFollowPosition;

        protected override void OnDisable()
        {
            base.OnDisable();
            HideAllEntries();
        }

        private void OnValidate()
        {
            _mapScale = Mathf.Max(1f, _mapScale);

            if (_worldMax.x < _worldMin.x)
                _worldMax.x = _worldMin.x;

            if (_worldMax.y < _worldMin.y)
                _worldMax.y = _worldMin.y;
        }

        private void OnDrawGizmosSelected()
        {
            var bottomLeft = GetWorldPoint(_worldMin);
            var topLeft = GetWorldPoint(new Vector2(_worldMin.x, _worldMax.y));
            var topRight = GetWorldPoint(_worldMax);
            var bottomRight = GetWorldPoint(new Vector2(_worldMax.x, _worldMin.y));

            Gizmos.color = new Color(0.15f, 0.85f, 1f, 1f);
            Gizmos.DrawLine(bottomLeft, topLeft);
            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, bottomRight);
            Gizmos.DrawLine(bottomRight, bottomLeft);

            Gizmos.DrawWireSphere(bottomLeft, 0.15f);
            Gizmos.DrawWireSphere(topRight, 0.15f);
        }

        internal Vector3 GetWorldPoint(Vector2 planePoint)
        {
            return _plane == ImageMinimapPlane.XZ
                ? new Vector3(planePoint.x, 0f, planePoint.y)
                : new Vector3(planePoint.x, planePoint.y, transform.position.z);
        }

        internal Vector2 GetPlanePoint(Vector3 worldPoint)
        {
            return _plane == ImageMinimapPlane.XZ
                ? new Vector2(worldPoint.x, worldPoint.z)
                : new Vector2(worldPoint.x, worldPoint.y);
        }

        [PublicAPI]
        public void Recenter()
        {
            _hasLastFollowPosition = false;
            _lastFollowPosition = default;
        }

        protected override void BeforeLayout(Camera cam)
        {
            UpdateContentTransform();
            UpdateMapImageLayout();
        }

        protected override void LateUpdate()
        {
            var panel = IndicatorPanel;
            if (panel == null)
                return;

            var cam = _camera != null ? _camera : Camera.main;
            BeforeLayout(cam);

            for (int i = _entries.Count - 1; i >= 0; i--)
            {
                var entry = _entries[i];

                if (entry.Target == null || entry.Rect == null)
                {
                    DestroyEntry(ref entry);
                    _entries.RemoveAt(i);
                    continue;
                }

                if (!entry.IsActive)
                {
                    entry.Rect.gameObject.SetActive(false);
                    _entries[i] = entry;
                    continue;
                }

                LayoutEntry(ref entry, cam);
                _entries[i] = entry;
            }
        }

        protected override void LayoutEntry(ref Entry entry, Camera cam)
        {
            var target = entry.Target;
            var rect = entry.Rect;
            var panel = IndicatorPanel;

            if (target == null || rect == null || panel == null || _mapImage == null)
                return;

            if (!TryGetMapNormalizedPosition(target.position, out var normalized))
            {
                rect.gameObject.SetActive(false);
                return;
            }

            var isFollowTarget = _followTarget != null && target == _followTarget;
            if (_hideOutsideMap &&
                !isFollowTarget &&
                (normalized.x < 0f || normalized.x > 1f || normalized.y < 0f || normalized.y > 1f))
            {
                rect.gameObject.SetActive(false);
                return;
            }

            var mapRect = _mapImage.rectTransform;
            var mapLocalPoint = GetMapLocalPoint(mapRect.rect, normalized);
            var worldOnPanel = mapRect.TransformPoint(mapLocalPoint);
            var localToParent = panel.InverseTransformPoint(worldOnPanel);

            rect.SetParent(panel, false);
            rect.localPosition = localToParent;
            rect.localRotation = Quaternion.identity;
            rect.gameObject.SetActive(true);
        }

        private void HideAllEntries()
        {
            for (var i = 0; i < _entries.Count; i++)
            {
                var rect = _entries[i].Rect;
                if (rect != null)
                    rect.gameObject.SetActive(false);
            }
        }

        private void UpdateContentTransform()
        {
            if (_mapImage == null)
                return;

            var rotation = Quaternion.identity;

            if (_rotateWithOrigin && _origin != null)
            {
                var angle = _plane == ImageMinimapPlane.XZ
                    ? _origin.eulerAngles.y
                    : _origin.eulerAngles.z;

                rotation = Quaternion.Euler(0f, 0f, -angle);
            }

            _mapImage.rectTransform.localRotation = rotation;
        }

        private void UpdateMapImageLayout()
        {
            if (_mapImage == null || IndicatorPanel == null)
                return;

            var imageRect = _mapImage.rectTransform;
            var fittedRect = GetMapRect(IndicatorPanel);

            imageRect.anchorMin = new Vector2(0.5f, 0.5f);
            imageRect.anchorMax = new Vector2(0.5f, 0.5f);
            imageRect.pivot = new Vector2(0.5f, 0.5f);
            imageRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, fittedRect.width * _mapScale);
            imageRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, fittedRect.height * _mapScale);
            imageRect.anchoredPosition = GetMapAnchoredPosition(imageRect);
            _mapImage.uvRect = new Rect(0f, 0f, 1f, 1f);
        }

        private bool TryGetMapNormalizedPosition(Vector3 worldPosition, out Vector2 normalized)
        {
            Vector2 mapPosition;
            switch (_plane)
            {
                case ImageMinimapPlane.XZ:
                    mapPosition = new Vector2(worldPosition.x, worldPosition.z);
                    break;

                case ImageMinimapPlane.XY:
                default:
                    mapPosition = new Vector2(worldPosition.x, worldPosition.y);
                    break;
            }

            var size = _worldMax - _worldMin;
            if (Mathf.Abs(size.x) < 0.0001f || Mathf.Abs(size.y) < 0.0001f)
            {
                normalized = default;
                return false;
            }

            normalized = new Vector2(
                (mapPosition.x - _worldMin.x) / size.x,
                (mapPosition.y - _worldMin.y) / size.y);
            return true;
        }

        private Vector2 GetMapAnchoredPosition(RectTransform mapImageRect)
        {
            if (!TryGetFollowPosition(out var followPosition))
                return Vector2.zero;

            var localPoint = GetMapLocalPoint(mapImageRect.rect, followPosition);
            var rotation = mapImageRect.localRotation;
            var rotatedPoint = rotation * new Vector3(localPoint.x, localPoint.y, 0f);
            return new Vector2(-rotatedPoint.x, -rotatedPoint.y);
        }

        private bool TryGetFollowPosition(out Vector2 followPosition)
        {
            followPosition = default;

            if (_followTarget != null && TryGetMapNormalizedPosition(_followTarget.position, out followPosition))
            {
                _lastFollowPosition = followPosition;
                _hasLastFollowPosition = true;
                return true;
            }

            if (_hasLastFollowPosition)
            {
                followPosition = _lastFollowPosition;
                return true;
            }

            return false;
        }

        private static Vector2 GetMapLocalPoint(Rect mapRect, Vector2 normalized)
        {
            return new Vector2(
                Mathf.LerpUnclamped(mapRect.xMin, mapRect.xMax, normalized.x),
                Mathf.LerpUnclamped(mapRect.yMin, mapRect.yMax, normalized.y));
        }

        private Rect GetMapRect(RectTransform panel)
        {
            var panelRect = panel.rect;
            var texture = _mapImage != null ? _mapImage.texture : null;
            if (texture == null)
                return panelRect;

            var mapAspect = texture.width / Mathf.Max((float)texture.height, 0.0001f);
            var panelAspect = panelRect.width / Mathf.Max(panelRect.height, 0.0001f);

            var width = panelRect.width;
            var height = panelRect.height;

            if (panelAspect > mapAspect)
            {
                width = height * mapAspect;
            }
            else
            {
                height = width / Mathf.Max(mapAspect, 0.0001f);
            }

            return new Rect(
                panelRect.center.x - width * 0.5f,
                panelRect.center.y - height * 0.5f,
                width,
                height);
        }
    }
}
