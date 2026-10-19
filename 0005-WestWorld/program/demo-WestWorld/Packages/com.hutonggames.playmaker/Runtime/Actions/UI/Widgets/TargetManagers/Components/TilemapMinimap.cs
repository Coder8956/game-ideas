using System;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Renders a simplified tilemap view into UI space and places tracked targets as blips in the same coordinates.
    /// Uses one or more Tilemaps for world-to-cell projection and merged minimap rendering.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Tilemap Minimap")]
    [Icon(Strings.EditorIconsPath + "RadarIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/target-managers/")]
    public sealed class TilemapMinimap : BaseTargetManager
    {
        [Serializable]
        public struct TileColorRule
        {
            public TileBase Tile;
            public Color Color;
        }

        private readonly struct RenderCell
        {
            public readonly TileBase Tile;
            public readonly Sprite Sprite;

            public bool HasContent => Tile != null || Sprite != null;

            public RenderCell(TileBase tile, Sprite sprite)
            {
                Tile = tile;
                Sprite = sprite;
            }
        }

        #region PublicAPI

        [PublicAPI]
        public List<Tilemap> Tilemaps
        {
            get => _tilemaps;
            set
            {
                _tilemaps = value ?? new List<Tilemap>();
                MarkMapDirty();
            }
        }

        [PublicAPI]
        public RawImage MapImage
        {
            get => _mapImage;
            set
            {
                _mapImage = value;
                MarkMapDirty();
            }
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

        public override RectTransform IndicatorPanel
        {
            get => _contentRoot != null ? _contentRoot : base.IndicatorPanel;
            set => base.IndicatorPanel = value;
        }

        #endregion

        [Tooltip("Tilemaps merged into the minimap render. The first valid tilemap supplies the grid used for world-to-cell projection. Last non-empty tile wins.")]
        [SerializeField]
        private List<Tilemap> _tilemaps = new();

        [Tooltip("RawImage that displays the generated minimap texture.")]
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

        [Tooltip("Hide blips when their projected cell lies outside the rendered map bounds.")]
        [SerializeField]
        private bool _hideOutsideMap = true;

        [Tooltip("Optional target used to center the visible minimap window.")]
        [SerializeField]
        private Transform _followTarget;

        [Tooltip("Zoom level for the visible map window. 1 shows the full map, 2 shows half-width/half-height, etc.")]
        [SerializeField]
        private float _mapScale = 1f;

        [Tooltip("If true, multiply tile colors by per-cell Tilemap colors.")]
        [SerializeField]
        private bool _useCellColors = true;

        [Tooltip("Color used for empty cells.")]
        [SerializeField]
        private Color _emptyColor = new Color(0f, 0f, 0f, 0f);

        [Tooltip("Fallback color used for any non-empty tile without an explicit color rule.")]
        [SerializeField]
        private Color _defaultTileColor = new Color(1f, 1f, 1f, 1f);

        [Tooltip("Upper bound for generated texture width/height. Larger tilemaps are downsampled.")]
        [SerializeField]
        private int _maxTextureSize = 256;

        [Tooltip("Optional per-tile color overrides.")]
        [SerializeField]
        private List<TileColorRule> _tileColors = new();

        [NonSerialized]
        private Texture2D _mapTexture;

        [NonSerialized]
        private bool _mapDirty = true;

        [NonSerialized]
        private BoundsInt _renderBounds;

        [NonSerialized]
        private bool _hasLastFollowPosition;

        [NonSerialized]
        private Vector2 _lastFollowPosition;

        protected override void Awake()
        {
            base.Awake();
            MarkMapDirty();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            MarkMapDirty();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            HideAllEntries();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (_mapTexture != null)
            {
                Destroy(_mapTexture);
                _mapTexture = null;
            }
        }

        private void OnValidate()
        {
            _maxTextureSize = Mathf.Max(1, _maxTextureSize);
            _mapScale = Mathf.Max(1f, _mapScale);
            MarkMapDirty();
        }

        protected override void BeforeLayout(Camera cam)
        {
            RebuildMapIfNeeded();
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

            if (target == null || rect == null || panel == null || GetProjectionTilemap() == null)
                return;

            if (!TryGetMapNormalizedPosition(target.position, out var normalized))
            {
                rect.gameObject.SetActive(false);
                return;
            }

            var isFollowTarget = IsFollowTarget(target);
            if (_hideOutsideMap &&
                !isFollowTarget &&
                (normalized.x < 0f || normalized.x > 1f || normalized.y < 0f || normalized.y > 1f))
            {
                rect.gameObject.SetActive(false);
                return;
            }

            var mapImageRect = _mapImage != null ? _mapImage.rectTransform : null;
            if (mapImageRect == null)
            {
                rect.gameObject.SetActive(false);
                return;
            }

            var mapLocalPoint = GetMapLocalPoint(mapImageRect.rect, normalized);
            var worldOnPanel = mapImageRect.TransformPoint(mapLocalPoint);
            var parent = panel;
            var localToParent = parent.InverseTransformPoint(worldOnPanel);

            rect.SetParent(parent, false);
            rect.localPosition = localToParent;
            rect.localRotation = Quaternion.identity;
            rect.gameObject.SetActive(true);
        }

        [PublicAPI]
        public void RefreshMap()
        {
            MarkMapDirty();
            RebuildMapIfNeeded();
        }

        [PublicAPI]
        public void Recenter()
        {
            _hasLastFollowPosition = false;
            _lastFollowPosition = default;
        }

        private void MarkMapDirty()
        {
            _mapDirty = true;
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

        private bool IsFollowTarget(Transform target)
        {
            return _followTarget != null && target == _followTarget;
        }

        private void UpdateContentTransform()
        {
            if (_mapImage == null)
                return;

            var rotation = Quaternion.identity;

            if (_rotateWithOrigin)
            {
                var projectionTilemap = GetProjectionTilemap();
                var source = _origin != null ? _origin : projectionTilemap != null ? projectionTilemap.transform : null;
                if (source != null)
                    rotation = Quaternion.Euler(0f, 0f, -source.eulerAngles.z);
            }

            _mapImage.rectTransform.localRotation = rotation;
        }

        private void RebuildMapIfNeeded()
        {
            if (!_mapDirty)
                return;

            _mapDirty = false;

            if (!TryGetRenderData(out var bounds, out var cells, out var colors))
            {
                _renderBounds = default;

                if (_mapImage != null)
                    _mapImage.texture = null;
                return;
            }

            var size = bounds.size;
            _renderBounds = bounds;
            var mapWidth = Mathf.Clamp(size.x, 1, _maxTextureSize);
            var mapHeight = Mathf.Clamp(size.y, 1, _maxTextureSize);

            if (_mapTexture == null || _mapTexture.width != mapWidth || _mapTexture.height != mapHeight)
            {
                if (_mapTexture != null)
                    Destroy(_mapTexture);

                _mapTexture = new Texture2D(mapWidth, mapHeight, TextureFormat.RGBA32, false)
                {
                    filterMode = FilterMode.Point,
                    wrapMode = TextureWrapMode.Clamp,
                    name = $"{name}_TilemapMinimap"
                };
            }

            var pixels = new Color32[mapWidth * mapHeight];
            var stepX = size.x / (float)mapWidth;
            var stepY = size.y / (float)mapHeight;

            for (int py = 0; py < mapHeight; py++)
            {
                for (int px = 0; px < mapWidth; px++)
                {
                    var sx = Mathf.Min(size.x - 1, Mathf.FloorToInt(px * stepX));
                    var sy = Mathf.Min(size.y - 1, Mathf.FloorToInt(py * stepY));
                    var index = sy * size.x + sx;
                    pixels[py * mapWidth + px] = ResolveCellColor(cells[index], colors, index);
                }
            }

            _mapTexture.SetPixels32(pixels);
            _mapTexture.Apply(false, false);

            if (_mapImage != null)
            {
                _mapImage.texture = _mapTexture;
            }
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
            normalized = default;

            var projectionTilemap = GetProjectionTilemap();
            if (projectionTilemap == null)
                return false;

            var bounds = _renderBounds.size.x > 0 && _renderBounds.size.y > 0
                ? _renderBounds
                : projectionTilemap.cellBounds;

            var size = bounds.size;
            if (size.x <= 0 || size.y <= 0)
                return false;

            var grid = projectionTilemap.layoutGrid;
            if (grid == null)
                return false;

            var localPosition = grid.transform.InverseTransformPoint(worldPosition);
            var cellPosition = grid.LocalToCellInterpolated(localPosition);

            var x = (cellPosition.x - bounds.xMin) / Mathf.Max(size.x, 1);
            var y = (cellPosition.y - bounds.yMin) / Mathf.Max(size.y, 1);

            normalized = new Vector2(x, y);
            return true;
        }

        private Vector2 GetMapAnchoredPosition(RectTransform mapImageRect)
        {
            if (!TryGetFollowPosition(out var followPosition))
                return Vector2.zero;

            var localPoint = GetMapLocalPoint(mapImageRect.rect, followPosition);
            var rotatedPoint = mapImageRect.localRotation * new Vector3(localPoint.x, localPoint.y, 0f);
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
            if (_renderBounds.size.x <= 0 || _renderBounds.size.y <= 0)
                return panelRect;

            var mapAspect = _renderBounds.size.x / (float)Mathf.Max(_renderBounds.size.y, 1);
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

        private bool TryGetRenderData(out BoundsInt bounds, out RenderCell[] cells, out Color[] colors)
        {
            bounds = default;
            cells = null;
            colors = null;

            if (!TryGetTilemaps(out var tilemaps))
                return false;

            var projectionTilemap = GetProjectionTilemap();
            if (projectionTilemap == null)
                return false;

            if (!TryGetCombinedBounds(tilemaps, projectionTilemap, out bounds))
                return false;

            var size = bounds.size;
            var cellCount = size.x * size.y;
            cells = new RenderCell[cellCount];
            colors = _useCellColors ? new Color[cellCount] : Array.Empty<Color>();

            for (var tilemapIndex = 0; tilemapIndex < tilemaps.Count; tilemapIndex++)
            {
                var tilemap = tilemaps[tilemapIndex];
                var sourceBounds = tilemap.cellBounds;
                var sourceColors = _useCellColors ? CaptureTilemapColors(tilemap, sourceBounds) : null;

                for (var y = 0; y < sourceBounds.size.y; y++)
                {
                    for (var x = 0; x < sourceBounds.size.x; x++)
                    {
                        var sourceIndex = y * sourceBounds.size.x + x;
                        var sourceCell = new Vector3Int(sourceBounds.x + x, sourceBounds.y + y, sourceBounds.z);
                        if (!TryGetRenderCell(tilemap, sourceCell, out var renderCell))
                            continue;

                        if (!TryGetProjectionCell(projectionTilemap, tilemap, sourceCell, out var projectionCell))
                            continue;

                        var targetX = projectionCell.x - bounds.xMin;
                        var targetY = projectionCell.y - bounds.yMin;
                        if (targetX < 0 || targetX >= size.x || targetY < 0 || targetY >= size.y)
                            continue;

                        var targetIndex = targetY * size.x + targetX;

                        cells[targetIndex] = renderCell;

                        if (_useCellColors && sourceColors != null)
                            colors[targetIndex] = sourceColors[sourceIndex];
                    }
                }
            }

            return true;
        }

        private Tilemap GetProjectionTilemap()
        {
            if (_tilemaps == null)
                return null;

            for (var i = 0; i < _tilemaps.Count; i++)
            {
                if (_tilemaps[i] != null)
                    return _tilemaps[i];
            }

            return null;
        }

        private bool TryGetTilemaps(out List<Tilemap> tilemaps)
        {
            tilemaps = new List<Tilemap>();

            if (_tilemaps != null)
            {
                for (var i = 0; i < _tilemaps.Count; i++)
                {
                    var tilemap = _tilemaps[i];
                    if (tilemap == null || tilemaps.Contains(tilemap))
                        continue;

                    tilemaps.Add(tilemap);
                }
            }

            return tilemaps.Count > 0;
        }

        private static bool TryGetCombinedBounds(IReadOnlyList<Tilemap> tilemaps, Tilemap projectionTilemap, out BoundsInt bounds)
        {
            bounds = default;

            var hasBounds = false;
            var minX = 0;
            var minY = 0;
            var maxX = 0;
            var maxY = 0;

            for (var i = 0; i < tilemaps.Count; i++)
            {
                var tilemap = tilemaps[i];
                if (tilemap == null)
                    continue;

                var cellBounds = tilemap.cellBounds;
                if (cellBounds.size.x <= 0 || cellBounds.size.y <= 0)
                    continue;

                for (var y = 0; y < cellBounds.size.y; y++)
                {
                    for (var x = 0; x < cellBounds.size.x; x++)
                    {
                        var sourceCell = new Vector3Int(cellBounds.x + x, cellBounds.y + y, cellBounds.z);
                        if (!TryGetRenderCell(tilemap, sourceCell, out _))
                            continue;

                        if (!TryGetProjectionCell(projectionTilemap, tilemap, sourceCell, out var projectionCell))
                            continue;

                        if (!hasBounds)
                        {
                            minX = projectionCell.x;
                            minY = projectionCell.y;
                            maxX = projectionCell.x;
                            maxY = projectionCell.y;
                            hasBounds = true;
                            continue;
                        }

                        minX = Mathf.Min(minX, projectionCell.x);
                        minY = Mathf.Min(minY, projectionCell.y);
                        maxX = Mathf.Max(maxX, projectionCell.x);
                        maxY = Mathf.Max(maxY, projectionCell.y);
                    }
                }
            }

            if (!hasBounds)
                return false;

            bounds = new BoundsInt(minX, minY, 0, maxX - minX + 1, maxY - minY + 1, 1);
            return bounds.size.x > 0 && bounds.size.y > 0;
        }

        private static bool TryGetRenderCell(Tilemap tilemap, Vector3Int cellPosition, out RenderCell renderCell)
        {
            renderCell = default;

            if (tilemap == null)
                return false;

            var tile = tilemap.GetTile(cellPosition);
            var sprite = tilemap.GetSprite(cellPosition);
            if (tile == null && sprite == null)
                return false;

            renderCell = new RenderCell(tile, sprite);
            return true;
        }

        private static bool TryGetProjectionCell(Tilemap projectionTilemap, Tilemap sourceTilemap, Vector3Int sourceCell, out Vector3Int projectionCell)
        {
            projectionCell = default;

            if (projectionTilemap == null || sourceTilemap == null)
                return false;

            var projectionGrid = projectionTilemap.layoutGrid;
            if (projectionGrid == null)
                return false;

            var worldPosition = sourceTilemap.GetCellCenterWorld(sourceCell);
            projectionCell = projectionGrid.WorldToCell(worldPosition);
            return true;
        }

        private static Color[] CaptureTilemapColors(Tilemap tilemap, BoundsInt bounds)
        {
            var size = bounds.size;
            var volume = size.x * size.y * size.z;
            var colors = new Color[volume];
            var index = 0;

            for (int z = 0; z < size.z; z++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    for (int x = 0; x < size.x; x++)
                    {
                        colors[index] = tilemap.GetColor(new Vector3Int(bounds.x + x, bounds.y + y, bounds.z + z));
                        index++;
                    }
                }
            }

            return colors;
        }

        private Color32 ResolveCellColor(RenderCell cell, IReadOnlyList<Color> colors, int index)
        {
            if (!cell.HasContent)
                return _emptyColor;

            var baseColor = cell.Tile != null && TryGetTileRuleColor(cell.Tile, out var ruleColor)
                ? ruleColor
                : _defaultTileColor;

            if (!_useCellColors || colors == null || index < 0 || index >= colors.Count)
                return baseColor;

            return baseColor * colors[index];
        }

        private bool TryGetTileRuleColor(TileBase tile, out Color color)
        {
            for (var i = 0; i < _tileColors.Count; i++)
            {
                if (_tileColors[i].Tile != tile)
                    continue;

                color = _tileColors[i].Color;
                return true;
            }

            color = default;
            return false;
        }
    }
}
