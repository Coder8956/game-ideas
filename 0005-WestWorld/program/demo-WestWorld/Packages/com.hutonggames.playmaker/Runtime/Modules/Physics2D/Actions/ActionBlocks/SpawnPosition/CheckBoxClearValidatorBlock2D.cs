using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Check Box Clear 2D")]
    [Tooltip("Require the candidate position to be clear of colliders within a box.")]
    public class CheckBoxClearValidatorBlock2D : SpawnPositionValidatorBlock2D
    {
        [Tooltip("Size used to test for blocking colliders.")]
        public Vector2Var Size;

        [Tooltip("A Layer mask that is used to selectively ignore colliders.")]
        [DefaultValue("~Physics2DDefaultRaycastLayers")]
        public LayerMaskVar LayerMask;

        [Tooltip("Only include objects with a Z coordinate (depth) greater than or equal to this value.")]
        [DefaultValue("~FloatNegativeInfinity")]
        public FloatVar MinDepth;

        [Tooltip("Only include objects with a Z coordinate (depth) less than or equal to this value.")]
        [DefaultValue("~FloatPositiveInfinity")]
        public FloatVar MaxDepth;

        public override bool IsValid => Size.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Size, LayerMask, MinDepth, MaxDepth);

        public override bool IsValidPosition(FindValidRandomPosition2D action)
        {
            return Physics2D.OverlapBox(action.CandidatePosition, Size.Value, action.CandidateRotation, LayerMask.Value, MinDepth.Value, MaxDepth.Value) == null;
        }

        public override string GetSummary() => "Box clear 2D";
    }
}
