using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Remove tiles at specific cell positions in a Tilemap.
    /// This is a convenience "carving" action for procedural generation.
    /// </summary>
    [Serializable, PublicAPI]
    [ActionCategory(Category.Tilemaps)]
    [ConvertibleGroup("TilemapSetTiles")]
    [ActionDescription(
        "Clears (removes) tiles in a Tilemap at the specified cell positions.\n\n" +
        "Use this after a generator action (like Drunkard's Walk, DLA, or Cellular Automata) " +
        "to carve out open space from a solid wall Tilemap.")]
    [HelpURL("actions/tilemap-actions/")]
    public sealed class TilemapClearCells : BaseAction
    {
        [Tooltip("The Tilemap to modify.")]
        [SerializeField] 
        private TilemapVar _tilemap;

        [Tooltip("List of cells to clear in tilemap local coordinates.\n" +
                 "These usually come from a procedural generator output.")]
        [SerializeField] 
        private Vector2IntListVar _cells;

        [Tooltip("Z position to clear at (usually 0 for 2D tilemaps).")]
        [SerializeField, DefaultValue(0)]
        private IntegerVar _z;

        public override bool CanExecute() => CheckParameters(_tilemap, _cells, _z);

        public override void Execute()
        {
            var tilemap = _tilemap.Value;
            var z = _z.Value;

            if (tilemap == null)
                return;

            // Carve: remove tiles at each provided cell
            var list = _cells.Value;
            if (list != null)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    var p = list[i];
                    var cellPos = new Vector3Int(p.x, p.y, z);
                    tilemap.SetTile(cellPos, null);
                }
            }

            tilemap.RefreshAllTiles();
        }

        public override string GetSummary() => "Clear {_tilemap} {_cells}" +
                                               (_z.IsNotDefault() ? " at Z {_z}" : "");
    }
}
