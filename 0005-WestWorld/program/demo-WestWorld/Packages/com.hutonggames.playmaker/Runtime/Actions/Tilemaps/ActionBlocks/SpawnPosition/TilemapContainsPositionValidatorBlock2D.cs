using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Tilemap Contains Position 2D")]
    [Tooltip("Require the candidate position to fall inside Tilemap cell bounds.")]
    public class TilemapContainsPositionValidatorBlock2D : SpawnPositionValidatorBlock2D
    {
        [Tooltip("Tilemap used for bounds validation.")]
        public TilemapVar Tilemap;

        [OptionalField]
        [DefaultValue(DefaultValueAttribute.None)]
        [Tooltip("Optional cell bounds to validate against. Leave empty to use the Tilemap's used tile bounds.")]
        public BoundsIntVar Bounds;

        public override bool IsValid => Tilemap.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Tilemap);

        public override bool IsValidPosition(FindValidRandomPosition2D action)
        {
            var tilemap = Tilemap.Value;
            var bounds = TilemapSpawnPosition2DUtility.ResolveBounds(tilemap, Bounds);
            var cell = TilemapSpawnPosition2DUtility.WorldToCell(tilemap, action.CandidatePosition);
            return bounds.Contains(cell);
        }

        public override string GetSummary() => "{Tilemap} contains position";
    }
}
