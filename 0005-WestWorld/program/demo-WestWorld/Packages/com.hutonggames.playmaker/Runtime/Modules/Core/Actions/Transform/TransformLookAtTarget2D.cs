using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [Serializable]
    [ActionCategory(Category.GameplayOrientationTransform)]
    [ConvertibleGroup("LookAt")]
    [ActionDescription("Rotate a Transform in 2D (around Z) so a chosen local axis faces another Transform. " +
                       "Includes SmoothTime and MaxSpeed.")]
    [HelpURL("actions/transform-actions/look-at-actions/")]
    public sealed class TransformLookAtTarget2D : BaseAction
    {
        public override UpdateMode DefaultUpdateMode  => UpdateMode.UpdateEveryFrame;

        [OwnerDefaultValue, Tooltip("The Transform to rotate.")]
        [SerializeField] private TransformVar _transform;

        [Tooltip("The target Transform to face.")]
        [SerializeField] private TransformVar _target;

        [Tooltip("Which local axis should face the target (2D: X / Y / -X / -Y).")]
        [SerializeField] private AxisDirection2DVar _facingAxis;

        [VarSlider(0.0f, 1.0f)]
        [Tooltip("Smooth Time in seconds (roughly time to halve the remaining angle). 0 = no smoothing.")]
        [SerializeField] private FloatVar _smoothTime;

        [VarSlider(0, 1080)]
        [Tooltip("Maximum turn speed in degrees per second. 0 = uncapped.")]
        [SerializeField] private FloatVar _maxSpeed;

        private Quaternion _desired;

        public override bool CanStart() =>
            CheckParameters(_transform, _target, _facingAxis);

        public override bool CanExecute() =>
            CheckParameters(_transform, _facingAxis);

        public override void Execute()
        {
            var t  = _transform.Value;
            var tf = _target.Value;

            if (t == null)
            {
                LogRuntimeError("Transform is None or null.");
                Finish();
                return;
            }

            if (tf == null)
            {
                Finish();
                return;
            }

            _desired = LookAtCompute.ComputeTargetRotationToPoint(
                t,
                tf.position,
                RotationConstraint.Z,
                _facingAxis.Value.ToAxisDirection(),
                Vector3.up // ignored in constrained mode
            );

            t.rotation = SmoothLookAtHelper.Update(t.rotation, _desired, _smoothTime.Value, _maxSpeed.Value);
        }

        public override string GetSummary()
        {
            var s = "Rotate {_transform} {_facingAxis} to look at {_target}";
            if (_smoothTime.IsNotDefault()) s += " in {_smoothTime}s";
            if (_maxSpeed.IsNotDefault())   s += " max {_maxSpeed}°/s";
            return s;
        }
    }
}
