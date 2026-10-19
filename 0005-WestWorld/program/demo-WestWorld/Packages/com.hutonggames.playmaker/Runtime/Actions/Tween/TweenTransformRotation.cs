using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween the rotation of a Transform.")]
    [LabelOverride("_value", "Rotation", "The rotation to tween from/to.")]
    public class TweenTransformRotation : BaseDirectionTweenAction<Quaternion, QuaternionVar>
    {
        [Tooltip("The Transform to Tween.")]
        [SerializeField, WriteOnly]
        private TransformVar _transform;
        
        public override bool CanExecute() => CheckParameters(_transform, _value) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();
            
            Distance = Quaternion.Angle(FromValue, ToValue);
        }

        protected override Quaternion GetCurrentValue() => _transform.Value.rotation;

        protected override Quaternion GetTargetValue() => 
            _relative.Value ? _transform.Value.rotation * _value.Value : _value.Value;

        public override void Execute()
        {
            base.Execute();

            _transform.Value.rotation = Quaternion.Slerp(FromValue, ToValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_transform} rotation {_direction} {_value}" + base.GetSummary();
    }
}