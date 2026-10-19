using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween the alpha of a CanvasGroup Component.")]
    public class TweenCanvasGroupAlpha : BaseTweenAction
    {
        [Tooltip("The CanvasGroup.")]
        [SerializeField]
        private CanvasGroupVar _canvasGroup;
        
        [Tooltip("Tween from or to the given value.")]
        [SerializeField]
        private TweenDirection _direction;
        
        [Tooltip("The alpha to tween from/to.")]
        [SerializeField]
        [DefaultValue(1f), VarSlider(0,1)]
        private FloatVar _alpha;

        [NonSerialized] private float _fromValue;
        [NonSerialized] private float _toValue;
        
        public override bool CanExecute() => CheckParameters(_canvasGroup, _alpha) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();
            
            if (_direction == TweenDirection.To)
            {
                _fromValue = _canvasGroup.Value.alpha;
                _toValue = _alpha.Value;
            }
            else
            {
                _fromValue = _alpha.Value;
                _toValue = _canvasGroup.Value.alpha;
            }
            
            Distance = Mathf.Abs(_toValue - _fromValue);
        }

        public override void Execute()
        {
            base.Execute();

            _canvasGroup.Value.alpha = Mathf.Lerp(_fromValue, _toValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_canvasGroup} Alpha {_direction} {_alpha}" + base.GetSummary();
    }
}