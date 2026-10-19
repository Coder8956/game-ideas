using System;
using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("In Target Cone")]
    [Tooltip("Require the candidate position to be inside a conical zone around a target Transform.")]
    public class InTargetConeValidatorBlock : SpawnPositionValidatorBlock
    {
        [OwnerDefaultValue]
        [Tooltip("Target Transform used as the local-space origin and orientation.")]
        public TransformVar Target;

        [DefaultValue(AxisDirection.Z)]
        [Tooltip("Local axis on the target Transform used as the center direction of the cone.")]
        public AxisDirectionVar Axis;

        [DefaultValue(0f)]
        [Tooltip("Minimum angle in degrees away from the axis.")]
        public FloatVar MinAngle;

        [DefaultValue(45f)]
        [Tooltip("Maximum angle in degrees away from the axis.")]
        public FloatVar MaxAngle;

        [DefaultValue(1f)]
        [Tooltip("Minimum allowed distance from the target.")]
        public FloatVar MinDistance;

        [DefaultValue(5f)]
        [Tooltip("Maximum allowed distance from the target.")]
        public FloatVar MaxDistance;

        public override bool IsValid => Target.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Target, Axis, MinAngle, MaxAngle, MinDistance, MaxDistance);

        public override bool IsValidPosition(FindValidRandomPosition action)
        {
            var target = Target.Value;
            if (target == null)
            {
                return false;
            }

            var offset = action.CandidatePosition - target.position;
            var distance = offset.magnitude;

            var minDistance = Mathf.Max(0f, MinDistance.Value);
            var maxDistance = Mathf.Max(minDistance, MaxDistance.Value);

            if (distance < minDistance || distance > maxDistance)
            {
                return false;
            }

            var axis = Axis.Value.GetDirection(target);
            axis.Normalize();
            if (axis == Vector3.zero)
            {
                axis = target.forward;
            }

            if (distance <= Mathf.Epsilon)
            {
                return minDistance <= 0f;
            }

            var minAngle = Mathf.Clamp(MinAngle.Value, 0f, 180f);
            var maxAngle = Mathf.Clamp(MaxAngle.Value, minAngle, 180f);
            var direction = offset / distance;
            var angle = Vector3.Angle(axis, direction);

            return angle >= minAngle && angle <= maxAngle;
        }

        public override string GetSummary() => "In target cone {Target}";
    }
}
