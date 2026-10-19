using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween a Float variable.")]
    public class TweenFloat : BaseDirectionTweenAction<float, FloatVar>
    {
        [DisplayOrder(-1)]
        [Tooltip("The float variable to tween.")]
        [SerializeField, WriteOnly]
        private FloatRef _float;
        
        public override bool CanExecute() => CheckParameters(_float) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();
            
            Distance = Mathf.Abs(FromValue - ToValue);
        }

        protected override float GetCurrentValue() => _float.Value;

        protected override float GetTargetValue() => _relative.Value ? _float.Value + _value.Value : _value.Value;

        public override void Execute()
        {
            base.Execute();

            _float.Value = Mathf.Lerp(FromValue, ToValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_float} {_direction} {_value}" + base.GetSummary();
    }
}