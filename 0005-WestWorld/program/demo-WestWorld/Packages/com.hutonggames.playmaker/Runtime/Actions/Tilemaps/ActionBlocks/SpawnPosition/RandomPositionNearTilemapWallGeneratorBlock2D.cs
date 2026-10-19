using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Position Near Tilemap Wall 2D")]
    [Tooltip("Generate a random 2D position in an empty Tilemap cell adjacent to a wall tile.")]
    public class RandomPositionNearTilemapWallGeneratorBlock2D : SpawnPositionGeneratorBlock2D
    {
        [Tooltip("Tilemap used for wall sampling.")]
        public TilemapVar Tilemap;

        [OptionalField]
        [DefaultValue(DefaultValueAttribute.None)]
        [Tooltip("Optional cell bounds to sample. Leave empty to use the Tilemap's used tile bounds.")]
        public BoundsIntVar Bounds;

        [DefaultValue(0.5f)]
        [Tooltip("Maximum world-space distance from occupied Tilemap cells.")]
        public FloatVar MaxDistance;

        [DefaultValue(false)]
        [Tooltip("If true, return a random point inside the sampled cell. Otherwise use the cell center.")]
        public BoolVar RandomPointInCell;

        public override bool IsValid => Tilemap.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Tilemap, MaxDistance, RandomPointInCell);

        public override void Generate(FindValidRandomPosition2D action)
        {
            var tilemap = Tilemap.Value;
            var bounds = TilemapSpawnPosition2DUtility.ResolveBounds(tilemap, Bounds);

            if (!TilemapSpawnPosition2DUtility.TryPickRandomNearWallCell(tilemap, bounds, MaxDistance.Value, out var cell))
            {
                action.CandidatePosition = Vector2.positiveInfinity;
                return;
            }

            action.CandidatePosition = TilemapSpawnPosition2DUtility.GetWorldPosition(tilemap, cell, RandomPointInCell.Value);
        }

        public override string GetSummary() => "Random position near wall in {Tilemap}";
    }
}
