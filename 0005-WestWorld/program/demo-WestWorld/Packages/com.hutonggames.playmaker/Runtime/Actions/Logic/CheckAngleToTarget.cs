using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicSpatial)]
    [ActionDescription("Check the angle between 2 objects.")]
    public class CheckAngleToTarget : BaseTrueFalseAction
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
        
        [Tooltip("The angle to check against.")]
        [SerializeField]
        private FloatVar _angle;
        
        private float _angleToTarget;
        
        protected override string TrueSummary => "{_fromObject} angle to {_target} is {_check} {_angle}";
        protected override string FalseSummary => "{_fromObject} angle to {_target} is not {_check} {_angle}";
        
        public override bool CanStart() => CheckParameters(_fromObject, _target, _angle);

        public override bool CanExecute() => CheckParameters(_fromObject, _angle);

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
            if (toTarget.sqrMagnitude <= 1e-10f)
            {
                _angleToTarget = 0f;
            }
            else
            {
                var forward = _forwardAxis.Value.GetDirection(from);
                _angleToTarget = Vector3.Angle(forward, toTarget);
            }
            
            return _check.Evaluate(_angleToTarget, _angle.Value);
        }

#if UNITY_EDITOR

        public override bool HasDebugInfo => true;
		
        public override string GetDebugInfo() => $"Angle: {_angleToTarget:0.##}";
		
#endif
    }
}
