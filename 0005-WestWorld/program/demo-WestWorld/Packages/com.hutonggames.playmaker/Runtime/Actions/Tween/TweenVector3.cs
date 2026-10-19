using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween a Vector3 variable.")]
    public class TweenVector3 : BaseDirectionTweenAction<Vector3, Vector3Var>
    {
        [Tooltip("The Vector3 variable to tween.")]
        [SerializeField, WriteOnly]
        private Vector3Ref _vector3;
        
        public override bool CanExecute() => CheckParameters(_vector3) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();
            
            Distance = Vector3.Distance(FromValue, ToValue);
        }

        protected override Vector3 GetCurrentValue() => _vector3.Value;

        protected override Vector3 GetTargetValue() => _relative.Value ? FromValue + _value.Value : _value.Value;

        public override void Execute()
        {
            base.Execute();

            _vector3.Value = Vector3.Lerp(FromValue, ToValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_vector3} {_direction} {_value}" + base.GetSummary();
    }
}