using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameplayTargetingTransform)]
    [ConvertibleGroup("TransformGetAngle")]
    [ActionDescription("Get the signed angle from the transform's forward direction to a target (in degrees).")]
    [HelpURL("actions/transform-actions/measurement-actions/")]
    public sealed class TransformGetSignedAngleToTarget : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;

        [Tooltip("The Target Transform.")]
        public TransformVar Target;

        [WriteOnly, Tooltip("Store the signed angle in degrees.")]
        public FloatRef GetAngle;

        [Tooltip("Which local axis is treated as the forward direction.")]
        [SerializeField, DefaultValue(AxisDirection.Z)]
        private AxisDirectionVar _forwardAxis;

        [Tooltip("Axis used to determine the sign of the angle (e.g., Y for yaw).")]
        [SerializeField, DefaultValue(AxisDirection.Y)]
        private AxisDirectionVar _signAxis;

        public override bool CanStart() =>
            CheckParameters(Transform, Target, GetAngle);

        public override bool CanExecute() =>
            CheckParameters(GetAngle);

        public override void Execute()
        {
            var t = Transform.Value;
            if (!t) return;

            var target = Target.Value;
            if (!target) return;

            var toTarget = target.position - t.position;
            if (toTarget.sqrMagnitude <= 1e-10f)
            {
                GetAngle.Value = 0f;
                return;
            }

            var forward = _forwardAxis.Value.GetDirection(t);
            var signAxis = _signAxis.Value.GetDirection(t);

            GetAngle.Value = Vector3.SignedAngle(forward, toTarget, signAxis);
        }

        public override string GetSummary() =>
            "Get {Transform} signed angle to {Target} -> {GetAngle}";
    }
}
