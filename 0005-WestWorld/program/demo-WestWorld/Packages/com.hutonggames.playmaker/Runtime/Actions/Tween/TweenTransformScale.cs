using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween the scale of a Transform.")]
    [LabelOverride("_value", "Scale", "The local scale to tween from/to.")]
    [LabelOverride("_relative", "Relative", "Multiply the current scale.")]
    public class TweenTransformScale : BaseDirectionTweenAction<Vector3, Vector3Var>
    {
        [Tooltip("The Transform to Tween.")]
        [SerializeField, WriteOnly]
        private TransformVar _transform;
        
        public override bool CanExecute() => CheckParameters(_transform, _value) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();
            
            Distance = Vector3.Distance(FromValue, ToValue);
        }

        protected override Vector3 GetCurrentValue() => _transform.Value.localScale;

        protected override Vector3 GetTargetValue()
        {
            if (!_relative.Value) return _value.Value;
            
            var scale = _transform.Value.localScale;
            return new Vector3(_value.Value.x * scale.x, _value.Value.y * scale.y, _value.Value.z * scale.z);
        }

        public override void Execute()
        {
            base.Execute();

            _transform.Value.localScale = Vector3.Lerp(FromValue, ToValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_transform} scale {_direction} {_value}" + base.GetSummary();
    }
}