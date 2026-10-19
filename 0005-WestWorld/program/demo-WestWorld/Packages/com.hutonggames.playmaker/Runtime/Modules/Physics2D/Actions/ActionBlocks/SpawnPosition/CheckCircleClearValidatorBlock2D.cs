using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Check Circle Clear 2D")]
    [Tooltip("Require the candidate position to be clear of colliders within a circle.")]
    public class CheckCircleClearValidatorBlock2D : SpawnPositionValidatorBlock2D
    {
        [DefaultValue(0.5f)]
        [Tooltip("Radius used to test for blocking colliders.")]
        public FloatVar Radius;

        [Tooltip("A Layer mask that is used to selectively ignore colliders.")]
        [DefaultValue("~Physics2DDefaultRaycastLayers")]
        public LayerMaskVar LayerMask;

        [Tooltip("Only include objects with a Z coordinate (depth) greater than or equal to this value.")]
        [DefaultValue("~FloatNegativeInfinity")]
        public FloatVar MinDepth;

        [Tooltip("Only include objects with a Z coordinate (depth) less than or equal to this value.")]
        [DefaultValue("~FloatPositiveInfinity")]
        public FloatVar MaxDepth;

        public override bool CanExecute() => Action.CheckParameters(Radius, LayerMask, MinDepth, MaxDepth);

        public override bool IsValidPosition(FindValidRandomPosition2D action)
        {
            return Physics2D.OverlapCircle(action.CandidatePosition, Radius.Value, LayerMask.Value, MinDepth.Value, MaxDepth.Value) == null;
        }

        public override string GetSummary() => "Circle clear 2D";
    }
}
