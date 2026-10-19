using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween a Quaternion variable.")]
    public class TweenQuaternion : BaseTweenAction
    {
        [Tooltip("The Quaternion variable to tween.")]
        [SerializeField, WriteOnly]
        private QuaternionRef _quaternion;
        
        [Tooltip("Tween from or to the given value.")]
        [SerializeField]
        private TweenDirection _direction;
        
        [Tooltip("The Quaternion value.")]
        [SerializeField]
        [DefaultValue(100f)]
        private QuaternionVar _value;

        [NonSerialized] private Quaternion _fromValue;
        [NonSerialized] private Quaternion _toValue;
        
        public override bool CanExecute() => CheckParameters(_quaternion, _value) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();

            if (_direction == TweenDirection.To)
            {
                _fromValue = _quaternion.Value;
                _toValue = _value.Value;
            }
            else
            {
                _fromValue = _value.Value;
                _toValue = _quaternion.Value;
            }
            
            Distance = Quaternion.Angle(_fromValue, _toValue);
        }

        public override void Execute()
        {
            base.Execute();

            _quaternion.Value = Quaternion.Slerp(_fromValue, _toValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_quaternion} {_direction} {_value}" + base.GetSummary();
    }
}