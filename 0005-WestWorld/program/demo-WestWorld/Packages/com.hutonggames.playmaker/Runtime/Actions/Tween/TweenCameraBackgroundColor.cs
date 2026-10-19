using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Tween)]
    [ActionDescription("Tween the background color of a Camera Component.")]
    public class TweenCameraBackgroundColor : BaseTweenAction
    {
        [Tooltip("The Camera.")]
        [SerializeField]
        private CameraVar _camera;
        
        [Tooltip("Tween from or to the given value.")]
        [SerializeField]
        private TweenDirection _direction;
        
        [Tooltip("The volume to tween from/to.")]
        [SerializeField]
        [DefaultValue(1f)]
        private ColorVar _backgroundColor;

        [NonSerialized] private Color _fromValue;
        [NonSerialized] private Color _toValue;
        
        public override bool CanExecute() => CheckParameters(_camera, _backgroundColor) && base.CanExecute();

        public override void OnStart()
        {
            base.OnStart();
            
            if (_direction == TweenDirection.To)
            {
                _fromValue = _camera.Value.backgroundColor;
                _toValue = _backgroundColor.Value;
            }
            else
            {
                _fromValue = _backgroundColor.Value;
                _toValue = _camera.Value.backgroundColor;
            }
            
            Distance = Vector4.Distance(_fromValue, _toValue);
        }

        public override void Execute()
        {
            base.Execute();

            _camera.Value.backgroundColor = Color.Lerp(_fromValue, _toValue, Easing.Evaluate(Progress));
        }

        public override string GetSummary() => "Tween {_camera} Background Color {_direction} {_backgroundColor}" + base.GetSummary();
    }
}