using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Tilemap No Tile 2D")]
    [Tooltip("Require the candidate position to map to a Tilemap cell that does not contain a tile.")]
    public class TilemapNoTileValidatorBlock2D : SpawnPositionValidatorBlock2D
    {
        [Tooltip("Tilemap used for tile validation.")]
        public TilemapVar Tilemap;

        public override bool IsValid => Tilemap.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Tilemap);

        public override bool IsValidPosition(FindValidRandomPosition2D action)
        {
            var tilemap = Tilemap.Value;
            var cell = TilemapSpawnPosition2DUtility.WorldToCell(tilemap, action.CandidatePosition);
            return !tilemap.HasTile(cell);
        }

        public override string GetSummary() => "{Tilemap} has no tile";
    }
}
