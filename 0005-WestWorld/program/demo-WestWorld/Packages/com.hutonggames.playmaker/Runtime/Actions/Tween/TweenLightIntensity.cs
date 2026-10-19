using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween the intensity of a Light Component.")]
    public class TweenLightIntensity : BaseTweenAction
    {
        [Tooltip("The Light.")]
        [SerializeField]
        private LightVar _light;
        
        [Tooltip("Tween from or to the given value.")]
        [SerializeField]
        private TweenDirection _direction;
        
        [Tooltip("The intensity to tween from/to.")]
        [SerializeField]
        [DefaultValue(1f)]
        private FloatVar _intensity;

        [NonSerialized] private float _fromValue;
        [NonSerialized] private float _toValue;
        
        public override bool CanExecute() => CheckParameters(_light, _intensity) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();

            if (_direction == TweenDirection.To)
            {
                _fromValue = _light.Value.intensity;
                _toValue = _intensity.Value;
            }
            else
            {
                _fromValue = _intensity.Value;
                _toValue = _light.Value.intensity;
            }
            
            Distance = Mathf.Abs(_toValue - _fromValue);
        }

        public override void Execute()
        {
            base.Execute();

            _light.Value.intensity = Mathf.Lerp(_fromValue, _toValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_light} Intensity {_direction} {_intensity}" + base.GetSummary();
    }
}