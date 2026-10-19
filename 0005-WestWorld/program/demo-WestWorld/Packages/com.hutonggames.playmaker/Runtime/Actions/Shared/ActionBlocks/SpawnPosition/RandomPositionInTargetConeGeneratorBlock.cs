using System;
using HutongGames.PlayMaker;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Random Position In Target Cone")]
    [Tooltip("Generate a random position in a local-space conical zone around a target Transform.")]
    public class RandomPositionInTargetConeGeneratorBlock : SpawnPositionGeneratorBlock
    {
        [OwnerDefaultValue]
        [Tooltip("Target Transform used as the local-space origin and orientation.")]
        public TransformVar Target;

        [DefaultValue(AxisDirection.Z)]
        [Tooltip("Local axis on the target Transform used as the center direction of the zone.")]
        public AxisDirectionVar Axis;

        [DefaultValue(0f)]
        [Tooltip("Minimum angle in degrees away from the axis.")]
        public FloatVar MinAngle;

        [DefaultValue(45f)]
        [Tooltip("Maximum angle in degrees away from the axis.")]
        public FloatVar MaxAngle;

        [DefaultValue(1f)]
        [Tooltip("Minimum distance from the target.")]
        public FloatVar MinDistance;

        [DefaultValue(5f)]
        [Tooltip("Maximum distance from the target.")]
        public FloatVar MaxDistance;

        [OptionalField]
        [Tooltip("Optional falloff controlling probability across the zone. Higher values near 0 bias closer to the axis and nearer distances; higher values near 1 bias toward the outer edge and farther distances.")]
        public AnimationCurveVar Falloff;

        public override bool IsValid => Target.HasValue();

        public override bool CanExecute() => Action.CheckParameters(Target, Axis, MinAngle, MaxAngle, MinDistance, MaxDistance);

        public override void Generate(FindValidRandomPosition action)
        {
            var target = Target.Value;
            if (target == null)
            {
                action.CandidatePosition = Vector3.zero;
                return;
            }

            var minDistance = Mathf.Max(0f, MinDistance.Value);
            var maxDistance = Mathf.Max(minDistance, MaxDistance.Value);

            var distanceT = CurveDistributionSampler.Sample01(Falloff);
            var distance = Mathf.Lerp(minDistance, maxDistance, distanceT);

            var axis = Axis.Value.GetDirection(target);
            axis.Normalize();
            if (axis == Vector3.zero)
            {
                axis = target.forward;
            }

            var minAngle = Mathf.Clamp(MinAngle.Value, 0f, 180f);
            var maxAngle = Mathf.Clamp(MaxAngle.Value, minAngle, 180f);

            if (maxAngle <= 0f)
            {
                action.CandidatePosition = target.position + axis * distance;
                return;
            }

            float t;
            if (Falloff == null || Falloff.IsNone || Falloff.Value == null)
                t = Random.value;
            else
                t = CurveDistributionSampler.Sample01(Falloff);

            var cosInner = Mathf.Cos(minAngle * Mathf.Deg2Rad);
            var cosOuter = Mathf.Cos(maxAngle * Mathf.Deg2Rad);
            var cosTheta = Mathf.Lerp(cosInner, cosOuter, t);
            var sinTheta = Mathf.Sqrt(1f - cosTheta * cosTheta);
            var phi = 2f * Mathf.PI * Random.value;

            var localDirection = new Vector3(
                sinTheta * Mathf.Cos(phi),
                sinTheta * Mathf.Sin(phi),
                cosTheta);

            var rotation = Quaternion.FromToRotation(Vector3.forward, axis);
            var direction = rotation * localDirection;
            if (direction == Vector3.zero)
            {
                direction = axis;
            }

            action.CandidatePosition = target.position + direction * distance;
        }

        public override string GetSummary() => "Random position in target cone";
    }
}
