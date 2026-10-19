using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween the anchored position of a RectTransform.")]
    public class TweenRectTransformAnchoredPosition3D : BaseTweenAction
    {
        [Tooltip("The RectTransform to Tween.")]
        [SerializeField, WriteOnly]
        private RectTransformVar _rectTransform;
        
        [Tooltip("Tween from or to the given value.")]
        [SerializeField]
        private TweenDirection _direction;
        
        [Tooltip("The anchored position to tween from/to.")]
        [SerializeField]
        [DefaultValue(1f)]
        private Vector3Var _position;

        [NonSerialized] private Vector3 _fromValue;
        [NonSerialized] private Vector3 _toValue;
        
        public override bool CanExecute() => CheckParameters(_rectTransform, _position) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();

            if (_direction == TweenDirection.To)
            {
                _fromValue = _rectTransform.Value.anchoredPosition3D;
                _toValue = _position.Value;
            }
            else
            {
                _fromValue = _position.Value;
                _toValue = _rectTransform.Value.anchoredPosition3D;
            }
            
            Distance = Vector3.Distance(_fromValue, _toValue);
        }

        public override void Execute()
        {
            base.Execute();

            _rectTransform.Value.anchoredPosition3D = Vector3.Lerp(_fromValue, _toValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_rectTransform} position {_direction} {_position}" + base.GetSummary();
    }
}