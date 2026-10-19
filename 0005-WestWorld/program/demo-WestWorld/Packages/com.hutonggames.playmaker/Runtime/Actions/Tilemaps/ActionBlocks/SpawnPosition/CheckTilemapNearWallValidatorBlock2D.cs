using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Check Tilemap Near Wall 2D")]
    [Tooltip("Require the candidate position to be within a maximum distance of occupied Tilemap cells, without being inside a wall tile.")]
    public class CheckTilemapNearWallValidatorBlock2D : SpawnPositionValidatorBlock2D
    {
        [Tooltip("Tilemap used as the wall source.")]
        public TilemapVar Tilemap;

        [OptionalField]
        [DefaultValue(DefaultValueAttribute.None)]
        [Tooltip("Optional cell bounds to check. Leave empty to use the Tilemap's used tile bounds.")]
        public BoundsIntVar Bounds;

        [DefaultValue(0.5f)]
        [Tooltip("Maximum world-space distance allowed from occupied Tilemap cells.")]
        public FloatVar MaxDistance;

        public override bool IsValid => Tilemap.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Tilemap, MaxDistance);

        public override bool IsValidPosition(FindValidRandomPosition2D action)
        {
            return TilemapSpawnPosition2DUtility.IsNearWall(Tilemap.Value, Bounds, action.CandidatePosition, MaxDistance.Value);
        }

        public override string GetSummary() => "Tilemap near wall";
    }
}
