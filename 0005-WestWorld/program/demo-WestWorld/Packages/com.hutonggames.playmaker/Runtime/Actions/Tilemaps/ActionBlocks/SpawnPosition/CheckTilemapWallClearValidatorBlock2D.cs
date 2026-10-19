using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Check Tilemap Wall Clear 2D")]
    [Tooltip("Require the candidate position to be at least a clearance radius away from occupied Tilemap cells.")]
    public class CheckTilemapWallClearValidatorBlock2D : SpawnPositionValidatorBlock2D
    {
        [Tooltip("Tilemap used as the wall source.")]
        public TilemapVar Tilemap;

        [OptionalField]
        [DefaultValue(DefaultValueAttribute.None)]
        [Tooltip("Optional cell bounds to check. Leave empty to use the Tilemap's used tile bounds.")]
        public BoundsIntVar Bounds;

        [DefaultValue(0.5f)]
        [Tooltip("Minimum world-space clearance required from occupied Tilemap cells.")]
        public FloatVar Clearance;

        public override bool IsValid => Tilemap.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Tilemap, Clearance);

        public override bool IsValidPosition(FindValidRandomPosition2D action)
        {
            return TilemapSpawnPosition2DUtility.IsCircleClearOfTiles(Tilemap.Value, Bounds, action.CandidatePosition, Clearance.Value);
        }

        public override string GetSummary() => "Tilemap wall clearance";
    }
}
