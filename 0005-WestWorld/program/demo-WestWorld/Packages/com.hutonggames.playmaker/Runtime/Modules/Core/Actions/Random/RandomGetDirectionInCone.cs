using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Random)]
    [ConvertibleGroup(ConvertibleGroup.RandomPosition)]
    [ActionDescription("Get a random direction inside a cone. Optionally bias the distribution using a falloff curve (x:0=center, 1=cone edge).")]
    public class RandomGetDirectionInCone : BaseAction
    {
        [Tooltip("The central axis of the cone.")]
        [SerializeField, DefaultValue("~Vector3Forward")]
        private Vector3Var _direction;

        [Tooltip("Maximum angle variance from the central axis. The total cone angle is twice this value.")]
        [SerializeField, DefaultValue(30f)]
        private FloatVar _angle;

        [Tooltip("Radius or magnitude of the resulting direction vector.")]
        [SerializeField, DefaultValue(1f)]
        private FloatVar _radius;

        [OptionalField]
        [Tooltip("Optional falloff controlling the distribution across the cone. " +
                 "x:0=center axis, x:1=cone edge. " +
                 "Higher y near 0 clusters toward the center; higher y near 1 pushes toward edges.")]
        [SerializeField]
        private AnimationCurveVar _falloff;

        [Tooltip("Store the random direction in a Vector3 variable.")]
        [SerializeField]
        private Vector3Ref _storeDirection;

        public override bool CanExecute() => CheckParameters(_direction, _radius, _angle, _storeDirection);

        public override void Execute()
        {
            // Get normalized axis
            var axis = _direction.Value;
            axis.Normalize();
            if (axis == Vector3.zero) axis = Vector3.forward;

            // Clamp angle
            var angleDeg = Mathf.Clamp(_angle.Value, 0f, 180f);
            if (angleDeg <= 0f)
            {
                _storeDirection.Value = axis * _radius.Value;
                return;
            }

            // --- Falloff sampling ---
            // Sample t in [0,1] (0=center, 1=edge)
            float t;
            if (_falloff == null || _falloff.IsNone || _falloff.Value == null)
                t = Random.value;
            else
                t = CurveDistributionSampler.Sample01(_falloff);

            // Convert t to an angle fraction
            // The cosine of theta defines how far from the cone axis
            // Normally cos(theta) is linear from [cosThetaMax, 1]
            // Here, we lerp using t to bias via the curve
            var cosThetaMax = Mathf.Cos(angleDeg * Mathf.Deg2Rad);
            var cosTheta = Mathf.Lerp(cosThetaMax, 1f, t);
            var sinTheta = Mathf.Sqrt(1f - cosTheta * cosTheta);

            // Uniform azimuthal rotation
            var phi = 2f * Mathf.PI * Random.value;

            // Local direction (+Z axis as cone axis)
            var localDir = new Vector3(
                sinTheta * Mathf.Cos(phi),
                sinTheta * Mathf.Sin(phi),
                cosTheta
            );

            // Rotate to align with target axis
            var rot = Quaternion.FromToRotation(Vector3.forward, axis);
            _storeDirection.Value = rot * localDir * _radius.Value;
        }

        public override string GetSummary()
        {
            var summary = "Get random direction in cone {_direction} {_angle}° ";
            if (_falloff.HasCurve()) summary += "({_falloff})";
            summary += " -> {_storeDirection}";
            return summary;
        }
    }
}
