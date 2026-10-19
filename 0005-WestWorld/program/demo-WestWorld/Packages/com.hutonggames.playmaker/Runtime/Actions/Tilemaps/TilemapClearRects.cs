using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Tilemaps)]
    [ConvertibleGroup("TilemapSetTiles")]
    [ActionDescription(
        "Clears multiple rectangular regions in a Tilemap.\n\n" +
        "Takes a list of rects (e.g., rooms, corridors) and clears every cell in each rect.")]
    [HelpURL("actions/tilemap-actions/")]
    public sealed class TilemapClearRects : BaseAction
    {
        [Tooltip("The Tilemap to write into.")]
        [SerializeField]
        private TilemapVar _tilemap;

        [Tooltip("The list of rects to fill, in cell coordinates. " +
                 "These should generally come from actions like BuildRandomRects or BuildRectCorridors.")]
        [SerializeField]
        private RectListVar _rects;

        [Tooltip("Z position to paint at (usually 0 for 2D tilemaps).")]
        [SerializeField, DefaultValue(0)]
        private IntegerVar _z;

        public override bool CanExecute() => CheckParameters(_tilemap, _rects, _z);

        public override void Execute()
        {
            var tilemap = _tilemap.Value;
            var z = _z.Value;

            if (tilemap == null) return;

            // Nothing to fill? done.
            var count = _rects.Count;
            if (count <= 0) return;

            for (var i = 0; i < count; i++)
            {
                var rect = _rects[i];

                // We assume rect is expressed in tile coords as floats.
                // We'll convert to inclusive tile bounds like RectInt.
                // rect.xMin / rect.yMin are the starting tiles.
                // rect.xMax / rect.yMax are exclusive in Unity Rect,
                // but our generator tends to build them so they line up with tiles.
                //
                // We'll make sure to cover all intended cells by:
                //   minX = Mathf.FloorToInt(xMin)
                //   minY = Mathf.FloorToInt(yMin)
                //   maxX = Mathf.CeilToInt(xMax) - 1
                //   maxY = Mathf.CeilToInt(yMax) - 1
                //
                // Example:
                //   Rect(x=10, y=5, w=4, h=3) =>
                //     xMin=10, xMax=14, ceil(14)-1 = 13
                //   So we fill x=10..13, width 4 cells. Good.
                //
                var minX = Mathf.FloorToInt(rect.xMin);
                var minY = Mathf.FloorToInt(rect.yMin);
                var maxX = Mathf.CeilToInt(rect.xMax) - 1;
                var maxY = Mathf.CeilToInt(rect.yMax) - 1;

                // Guard empty / degenerate rects
                if (maxX < minX || maxY < minY)
                    continue;

                for (var y = minY; y <= maxY; y++)
                {
                    for (var x = minX; x <= maxX; x++)
                    {
                        tilemap.SetTile(new Vector3Int(x, y, z), null);
                    }
                }
            }

            tilemap.RefreshAllTiles();
        }

        public override string GetSummary() => "Clear {_tilemap} {_rects}" +
                                               (_z.IsNotDefault() ? " at Z {_z}" : "");
    }
}
