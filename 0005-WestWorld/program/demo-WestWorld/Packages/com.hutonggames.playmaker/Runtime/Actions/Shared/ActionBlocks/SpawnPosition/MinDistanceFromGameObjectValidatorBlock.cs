using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Min Distance From GameObject")]
    [Tooltip("Require the candidate position to be at least a minimum distance from a GameObject.")]
    public class MinDistanceFromGameObjectValidatorBlock : SpawnPositionValidatorBlock
    {
        [Tooltip("Target GameObject.")]
        public GameObjectVar Target;

        [DefaultValue(1f)]
        [Tooltip("Minimum allowed distance from the target.")]
        public FloatVar MinDistance;

        public override bool IsValid => Target.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Target, MinDistance);

        public override bool IsValidPosition(FindValidRandomPosition action)
        {
            return Vector3.Distance(action.CandidatePosition, Target.Transform.position) >= MinDistance.Value;
        }

        public override string GetSummary() => "Min distance from {Target}";
    }
}
