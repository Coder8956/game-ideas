using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Tilemaps)]
    [ConvertibleGroup("TilemapSetTiles")]
    [ActionDescription(
        "Fill a rectangular region in a Tilemap with a tile.\n\n" +
        "Uses a RectInt for the fill area.\n\n" +
        "This always writes every cell in the region, unlike Unity's Tilemap.BoxFill(), " +
        "which behaves more like a flood fill and can be blocked by existing tiles.")]
    [HelpURL("actions/tilemap-actions/")]
    public sealed class TilemapFillRect : BaseAction
    {
        [Tooltip("The Tilemap to write into.")]
        [SerializeField] 
        private TilemapVar _tilemap;

        [Tooltip("Tile to place in each filled cell.")]
        [SerializeField, OptionalField] 
        private TileBaseVar _tile;

        [Tooltip("The rectangular region to fill, in cell coordinates.")]
        [SerializeField, DefaultValue("0,0,5,5")]
        private RectIntVar _rect;

        [Tooltip("Z position to paint at (usually 0 for 2D tilemaps).")]
        [SerializeField, DefaultValue(0)]
        private IntegerVar _z;

        public override bool CanExecute() => CheckParameters(_tilemap, _rect, _z);

        public override void Execute()
        {
            var tilemap = _tilemap.Value;
            var tile    = _tile.Value;
            var z       = _z.Value;
            var rect    = _rect.Value;    // RectInt: x,y,width,height

            // RectInt.x/y = min corner.
            // RectInt.width/height are extents (not inclusive).
            // So the max inclusive cell is x + width - 1, y + height - 1.

            var minX = rect.x;
            var minY = rect.y;
            var maxX = rect.x + rect.width  - 1;
            var maxY = rect.y + rect.height - 1;

            // Guard: empty / negative sizes shouldn't nuke anything.
            // If width or height <= 0, just exit early.
            if (rect.width <= 0 || rect.height <= 0)
                return;

            for (var y = minY; y <= maxY; y++)
            {
                for (var x = minX; x <= maxX; x++)
                {
                    tilemap.SetTile(new Vector3Int(x, y, z), tile);
                }
            }

            tilemap.RefreshAllTiles();
        }

        public override string GetSummary() => "Fill {_tilemap} {_rect} with {_tile}" +
                                               (_z.IsNotDefault() ? " at Z {_z}" : "");
    }
}
