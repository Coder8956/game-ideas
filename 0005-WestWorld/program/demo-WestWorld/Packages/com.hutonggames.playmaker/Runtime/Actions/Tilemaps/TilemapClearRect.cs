using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Tilemaps)]
    [ConvertibleGroup("TilemapSetTiles")]
    [ActionDescription("Clears a rectangular region in a Tilemap.")]
    [HelpURL("actions/tilemap-actions/")]
    public sealed class TilemapClearRect : BaseAction
    {
        [Tooltip("The Tilemap to write into.")]
        [SerializeField] 
        private TilemapVar _tilemap;

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
                    tilemap.SetTile(new Vector3Int(x, y, z), null);
                }
            }

            tilemap.RefreshAllTiles();
        }

        public override string GetSummary() => "Clear {_tilemap} {_rect}" +
                                               (_z.IsNotDefault() ? " at Z {_z}" : "");
    }
}
