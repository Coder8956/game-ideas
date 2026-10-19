using System;
using HutongGames.Extensions;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween a Rect variable.")]
    public class TweenRect : BaseTweenAction
    {
        [Tooltip("The Rect variable to tween.")]
        [SerializeField, WriteOnly]
        private RectRef _rect;
        
        [Tooltip("Tween from or to the given value.")]
        [SerializeField]
        private TweenDirection _direction;
        
        [Tooltip("The Rect value to tween to.")]
        [SerializeField]
        private RectVar _value;

        [NonSerialized] private Rect _fromValue;
        [NonSerialized] private Rect _toValue;
        
        public override bool CanExecute() => CheckParameters(_rect, _value) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();

            if (_direction == TweenDirection.To)
            {
                _fromValue = _rect.Value;
                _toValue = _value.Value;
            }
            else
            {
                _fromValue = _value.Value;
                _toValue = _rect.Value;
            }

            // TODO: Not sure if this is the best Distance calculation
            // Used for speed based tweens...
            Distance = Mathf.Abs(_fromValue.Area() - _toValue.Area());
        }

        public override void Execute()
        {
            base.Execute();

            _rect.Value = _fromValue.Lerp(_toValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_rect} {_direction} {_value}" + base.GetSummary();
    }
}