using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween a Material's main texture offset. E.g., to scroll the texture.")]
    public class TweenMainTextureOffset : BaseTweenAction
    {
        [Tooltip("The Material.")]
        [SerializeField]
        private MaterialVar _material;
        
        [Tooltip("Tween from or to the given value.")]
        [SerializeField]
        private TweenDirection _direction;
        
        [Tooltip("The offset to tween from/to.")]
        [SerializeField]
        [DefaultValue(1f)]
        private Vector2Var _offset;

        [NonSerialized] private Vector2 _fromValue;
        [NonSerialized] private Vector2 _toValue;
        
        public override bool CanExecute() => CheckParameters(_material, _offset) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();

            if (_direction == TweenDirection.To)
            {
                _fromValue = _material.Value.mainTextureOffset;
                _toValue = _offset.Value;
            }
            else
            {
                _fromValue = _offset.Value;
                _toValue = _material.Value.mainTextureOffset;
            }
            
            Distance = Vector2.Distance(_toValue, _fromValue);
        }

        public override void Execute()
        {
            base.Execute();

            _material.Value.mainTextureOffset = Vector2.Lerp(_fromValue, _toValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_material} Texture Offset {_direction} {_offset}" + base.GetSummary();
    }
}