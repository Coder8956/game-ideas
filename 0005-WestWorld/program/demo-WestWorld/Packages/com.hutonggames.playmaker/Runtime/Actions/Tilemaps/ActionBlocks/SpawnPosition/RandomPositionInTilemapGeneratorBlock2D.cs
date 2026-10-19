using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Position In Tilemap 2D")]
    [Tooltip("Generate a random 2D position from a Tilemap cell.")]
    public class RandomPositionInTilemapGeneratorBlock2D : SpawnPositionGeneratorBlock2D
    {
        [Tooltip("Tilemap used for cell sampling.")]
        public TilemapVar Tilemap;

        [OptionalField]
        [DefaultValue(DefaultValueAttribute.None)]
        [Tooltip("Optional cell bounds to sample. Leave empty to use the Tilemap's used tile bounds.")]
        public BoundsIntVar Bounds;

        [DefaultValue(TilemapCellSampleMode.OccupiedCell)]
        [Tooltip("Choose whether to sample any cell, only occupied cells, or only empty cells.")]
        public TilemapCellSampleMode SampleMode;

        [DefaultValue(false)]
        [Tooltip("If true, return a random point inside the sampled cell. Otherwise use the cell center.")]
        public BoolVar RandomPointInCell;

        public override bool IsValid => Tilemap.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Tilemap, RandomPointInCell);

        public override void Generate(FindValidRandomPosition2D action)
        {
            var tilemap = Tilemap.Value;
            var bounds = TilemapSpawnPosition2DUtility.ResolveBounds(tilemap, Bounds);

            if (!TilemapSpawnPosition2DUtility.TryPickRandomCell(tilemap, bounds, SampleMode, out var cell))
            {
                action.CandidatePosition = Vector2.positiveInfinity;
                return;
            }

            action.CandidatePosition = TilemapSpawnPosition2DUtility.GetWorldPosition(tilemap, cell, RandomPointInCell.Value);
        }

        public override string GetSummary() => "Random position in {Tilemap}";
    }
}
