using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween a Color variable.")]
    public class TweenColor : BaseTweenAction
    {
        [Tooltip("The color variable to tween.")]
        [SerializeField, WriteOnly]
        private ColorRef _color;
        
        [Tooltip("Tween from or to the given value.")]
        [SerializeField]
        private TweenDirection _direction;
        
        [Tooltip("The color to tween to.")]
        [SerializeField]
        [DefaultValue("Color.white")]
        private ColorVar _value;

        [NonSerialized] private Color _fromColor;
        [NonSerialized] private Color _toColor;
        
        public override bool CanExecute() => CheckParameters(_color, _value) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();

            if (_direction == TweenDirection.To)
            {
                _fromColor = _color.Value;
                _toColor = _value.Value;
            }
            else
            {
                _fromColor = _value.Value;
                _toColor = _color.Value;
            }
            
            Distance = Vector4.Distance(_fromColor, _toColor);
        }

        public override void Execute()
        {
            base.Execute();

            _color.Value = Color.Lerp(_fromColor, _toColor, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_color} {_direction} {_value}" + base.GetSummary();
    }
}