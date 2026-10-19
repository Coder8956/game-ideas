using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween the local position of a Transform.")]
    [LabelOverride("_value", "Position", "The local position to tween from/to.")]
    public class TweenTransformLocalPosition : BaseDirectionTweenAction<Vector3, Vector3Var>
    {
        [Tooltip("The Transform to Tween.")]
        [SerializeField, WriteOnly]
        private TransformVar _transform;
        
        public override bool CanExecute() => CheckParameters(_transform) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();
            
            Distance = Vector3.Distance(FromValue, ToValue);
        }

        protected override Vector3 GetCurrentValue() => _transform.Value.localPosition;

        protected override Vector3 GetTargetValue() => 
            _relative.Value ? _transform.Value.localPosition + _value.Value : _value.Value;

        public override void Execute()
        {
            base.Execute();

            _transform.Value.localPosition = Vector3.Lerp(FromValue, ToValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_transform} local position {_direction} {_value}" 
                                               + base.GetSummary();
    }
}