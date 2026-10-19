using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Tilemaps)]
    [ConvertibleGroup("TilemapSetTiles")]
    [ActionDescription("Set a list of Tilemap cells to a Tile. Leave Tile empty/None to clear those cells.")]
    [HelpURL("actions/tilemap-actions/")]
    public sealed class TilemapSetCells : BaseAction
    {
        // ---------- Inputs ----------

        [ActionHeader("Tilemap")]
        [Tooltip("Target Tilemap.")]
        [SerializeField] 
        private TilemapVar _tilemap;

        [Tooltip("Local cell positions to modify.")]
        [SerializeField] 
        private Vector2IntListVar _cells;

        [ActionHeader("Paint")]
        [Tooltip("Tile to assign to each cell. Leave None to clear those cells.")]
        [SerializeField, OptionalField] 
        private TileBaseVar _tile;

        // ---------- Outputs (Optional) ----------

        [ActionHeader("Output")]
        [Tooltip("Total cells written.")]
        [SerializeField, WriteOnly, OptionalField]
        private IntegerRef _changedCount;

        // ---------- Execution ----------

        public override bool CanExecute() =>
            CheckParameters(_tilemap, _cells);

        public override void Execute()
        {
            var tilemap = _tilemap.Value;
            if (tilemap == null) return;

            var tileToSet = _tile.Value; // can be null to clear

            var written = 0;
            var cellList = _cells.Value;

            for (var i = 0; i < cellList.Count; i++)
            {
                var cellPos = (Vector3Int)cellList[i];
                tilemap.SetTile(cellPos, tileToSet);
                written++;
            }

            if (!_changedCount.IsNone)
            {
                _changedCount.Value = written;
            }
        }

        public override string GetSummary() => "Set {_tilemap} {_cells} to {_tile}";
    }
}