using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameplayTargetingTransform)]
    [ConvertibleGroup("TransformGetAngle")]
    [ActionDescription("Get the angle from the transform's forward direction to a target (in degrees).")]
    [HelpURL("actions/transform-actions/measurement-actions/")]
    public sealed class TransformGetAngleToTarget : BaseAction
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
            GetAngle.Value = Vector3.Angle(forward, toTarget);
        }

        public override string GetSummary() =>
            "Get {Transform} angle to {Target} -> {GetAngle}";
    }
}
