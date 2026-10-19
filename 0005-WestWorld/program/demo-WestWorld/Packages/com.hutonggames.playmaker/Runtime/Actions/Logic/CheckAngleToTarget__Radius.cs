using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicSpatial)]
    [ActionDescription("Check the angle between 2 objects, compensating for a target radius (angular size).")]
    public class CheckAngleToTarget__Radius : BaseTrueFalseAction
    {
        [Tooltip("The Transform to check the angle from.")]
        [SerializeField]
        private TransformVar _fromObject;

        [Tooltip("Which local axis is treated as the forward direction.")]
        [SerializeField, DefaultValue(AxisDirection.Z)]
        private AxisDirectionVar _forwardAxis;

        [Tooltip("The Transform to check angle to.")]
        [SerializeField]
        private TransformVar _target;

        [Tooltip("The check to perform."), DefaultValue("LessThan")]
        [SerializeField]
        private NumericComparisonOperation _check;

        [Tooltip("The angle to check against (base cone angle).")]
        [SerializeField]
        private FloatVar _angle;

        [Tooltip("Radius of the target for angular size compensation. " +
                 "Larger radius makes the angle test easier to pass.")]
        [SerializeField, DefaultValue(0f)]
        private FloatVar _targetRadius;

        private float _angleToTarget;
        private float _angularRadius;

        protected override string TrueSummary =>
            "{_fromObject} angle to {_target} is {_check} {_angle}";

        protected override string FalseSummary =>
            "{_fromObject} angle to {_target} is not {_check} {_angle}";

        public override bool CanStart() =>
            CheckParameters(_fromObject, _target, _angle, _targetRadius);

        public override bool CanExecute() =>
            CheckParameters(_fromObject, _angle, _targetRadius);

        protected override bool Test()
        {
            var from = _fromObject.Value;
            if (!from) return false;

            var target = _target.Value;
            if (!target)
            {
                Finish();
                return false;
            }

            var toTarget = target.position - from.position;
            var sqrDist = toTarget.sqrMagnitude;

            if (sqrDist <= 1e-10f)
            {
                _angleToTarget = 0f;
                _angularRadius = 0f;
            }
            else
            {
                var forward = _forwardAxis.Value.GetDirection(from);
                _angleToTarget = Vector3.Angle(forward, toTarget);

                // Target angular radius compensation
                var dist = Mathf.Sqrt(sqrDist);
                var R = Mathf.Max(0f, _targetRadius.Value);

                if (R > 0f)
                {
                    // arctan(R / dist) converted to degrees
                    _angularRadius = Mathf.Atan2(R, dist) * Mathf.Rad2Deg;
                }
                else
                {
                    _angularRadius = 0f;
                }
            }

            // Relaxed angle due to radius (target size)
            var compensatedAngle = _angleToTarget - _angularRadius;

            // Example: check “angle <= maxAngle” but adjusted by -angularRadius
            return _check.Evaluate(compensatedAngle, _angle.Value);
        }

#if UNITY_EDITOR

        public override bool HasDebugInfo => true;

        public override string GetDebugInfo() =>
            $"Angle: {_angleToTarget:0.##}  |  RadiusComp: {_angularRadius:0.##}";

#endif
    }
}
