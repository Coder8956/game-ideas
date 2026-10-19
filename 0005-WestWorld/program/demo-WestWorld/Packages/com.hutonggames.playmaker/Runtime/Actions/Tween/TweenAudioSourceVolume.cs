using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween the volume of an AudioSource Component.")]
    public class TweenAudioSourceVolume : BaseTweenAction
    {
        [Tooltip("The AudioSource.")]
        [SerializeField]
        private AudioSourceVar _audioSource;
        
        [Tooltip("Tween from or to the given value.")]
        [SerializeField]
        private TweenDirection _direction;
        
        [Tooltip("The volume to tween from/to.")]
        [SerializeField]
        [DefaultValue(1f), VarSlider(0,1)]
        private FloatVar _volume;

        [NonSerialized] private float _fromValue;
        [NonSerialized] private float _toValue;
        
        public override bool CanExecute() => CheckParameters(_audioSource, _volume) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();
            
            if (_direction == TweenDirection.To)
            {
                _fromValue = _audioSource.Value.volume;
                _toValue = _volume.Value;
            }
            else
            {
                _fromValue = _volume.Value;
                _toValue = _audioSource.Value.volume;
            }
            
            Distance = Mathf.Abs(_toValue - _fromValue);
        }

        public override void Execute()
        {
            base.Execute();

            _audioSource.Value.volume = Mathf.Lerp(_fromValue, _toValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_audioSource} Volume {_direction} {_volume}" + base.GetSummary();
    }
}