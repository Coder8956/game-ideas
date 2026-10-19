using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Min Distance From GameObject 2D")]
    [Tooltip("Require the candidate position to be at least a minimum 2D distance from a GameObject.")]
    public class MinDistanceFromGameObjectValidatorBlock2D : SpawnPositionValidatorBlock2D
    {
        [Tooltip("Target GameObject.")]
        public GameObjectVar Target;

        [DefaultValue(1f)]
        [Tooltip("Minimum allowed distance from the target.")]
        public FloatVar MinDistance;

        public override bool IsValid => Target.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Target, MinDistance);

        public override bool IsValidPosition(FindValidRandomPosition2D action)
        {
            return Vector2.Distance(action.CandidatePosition, Target.Transform.position) >= MinDistance.Value;
        }

        public override string GetSummary() => "Min distance from {Target}";
    }
}
