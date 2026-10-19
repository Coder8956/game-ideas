using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween a Vector2 variable.")]
    public class TweenVector2 : BaseDirectionTweenAction<Vector2, Vector2Var>
    {
        [Tooltip("The Vector2 variable to tween.")]
        [SerializeField, WriteOnly]
        private Vector2Ref _vector2;
        
        public override bool CanExecute() => CheckParameters(_vector2) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();
            
            Distance = Vector2.Distance(FromValue, ToValue);
        }

        protected override Vector2 GetCurrentValue() => _vector2.Value;

        protected override Vector2 GetTargetValue() => _relative.Value ? FromValue + _value.Value : _value.Value;

        public override void Execute()
        {
            base.Execute();

            _vector2.Value = Vector2.Lerp(FromValue, ToValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_vector2} {_direction} {_value}" + base.GetSummary();
    }
}