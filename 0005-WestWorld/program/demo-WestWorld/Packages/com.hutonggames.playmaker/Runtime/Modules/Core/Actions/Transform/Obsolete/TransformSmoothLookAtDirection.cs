using System;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	[Obsolete("Use TransformLookAtDirection instead.")]
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("LookAt")]
    [ActionDescription("Smoothly rotates the transform so the forward vector points in a direction.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.LookAt.html")]
    public sealed class TransformSmoothLookAtDirection : BaseAction
    {
	    public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
	    public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;

	    [OwnerDefaultValue]
        [Tooltip("The Transform to rotate.")]
        [SerializeField]
        private TransformVar _transform;
		
        [Tooltip("Rotate Transform to look at direction.")]
        [SerializeField]
        private Vector3Var _direction;
		
        [VarSlider(0.01f, 1.0f), DefaultValue(0.3f)]
        [Tooltip("Smooth Time in seconds (roughly the time to halve the position error). Smaller = snappier.")]
        [SerializeField] private FloatVar _smoothTime;
        
        [FormerlySerializedAs("Speed")]
        [VarSlider(0, 1080)]
        [Tooltip("Optional max angular speed in degrees per second. 0 = uncapped.")]
        public FloatVar MaxSpeed;
        
        [DefaultValue("~Vector3Up")]
        [Tooltip("Vector specifying the upward direction.")]
        [SerializeField]
        private Vector3Var _worldUp;
        
        private Quaternion _desiredRotation;
		
        public override bool CanExecute() => CheckParameters(_transform, _direction, _smoothTime);

        public override void Execute()
        {
	        var transform = _transform.Value;
	        if (transform == null) return;
	        
            var diff = _direction.Value;
            if (diff != Vector3.zero && diff.sqrMagnitude > 0)
            {
	            _desiredRotation = Quaternion.LookRotation(diff, _worldUp.IsNone ? Vector3.up : _worldUp.Value);
            }

            var currentRotation = transform.rotation;
            transform.rotation = SmoothLookAtHelper.Update(currentRotation, _desiredRotation, _smoothTime.Value, MaxSpeed.Value);
        }
		
        public override string GetSummary()
        {
	        var s = "{_transform} smooth look at {_direction} in {_smoothTime}s";
	        if (MaxSpeed.IsVariable || MaxSpeed.Value > 0f) s += " max {MaxSpeed}°/s";
	        if (_worldUp.IsVariable || _worldUp.Value != Vector3.up) s += " ({_worldUp})";
	        return s;
        }    
    }
}