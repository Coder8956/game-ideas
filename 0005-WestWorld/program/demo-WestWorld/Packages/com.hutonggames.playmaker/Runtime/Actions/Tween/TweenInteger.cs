using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween an Integer variable." +
                       "<br/>NOTE: Tween is done as a float, then rounded to an integer value.")]
    public class TweenInteger : BaseDirectionTweenAction<int, IntegerVar>
    {
        [Tooltip("The Integer variable to tween.")]
        [SerializeField, WriteOnly]
        private IntegerRef _integer;
        
        public override bool CanExecute() => CheckParameters(_integer) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();
            
            Distance = Mathf.Abs(FromValue - ToValue);
        }

        protected override int GetCurrentValue() => _integer.Value;

        protected override int GetTargetValue() => _relative.Value ? _integer.Value + _value.Value : _value.Value;

        public override void Execute()
        {
            base.Execute();

            var floatLerp = Mathf.Lerp(FromValue, ToValue, Easing.Evaluate(Progress));
            _integer.Value = Mathf.RoundToInt(floatLerp);
        }

        public override string GetSummary() => "Tween {_integer} {_direction} {_value}" + base.GetSummary();
    }
}