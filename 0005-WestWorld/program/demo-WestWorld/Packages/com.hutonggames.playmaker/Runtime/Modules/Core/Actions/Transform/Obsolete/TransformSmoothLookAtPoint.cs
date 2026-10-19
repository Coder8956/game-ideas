using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;


namespace HutongGames.PlayMaker.Actions
{
	
	[System.Serializable]
	[Obsolete("Use TransformLookAtPoint instead.")]
    [PublicAPI]
    [HasSceneGUI]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("LookAt")]
    [ActionDescription("Smoothly rotates the transform so the forward vector points at worldPosition.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.LookAt.html")]
    public sealed class TransformSmoothLookAtPoint : BaseAction
    {
	    public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
	    public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
	    
        public Transform Transform => _transform.Value;
        public Vector3Var WorldPosition => _worldPosition;
		
        [OwnerDefaultValue]
        [Tooltip("The Transform to rotate.")]
        [SerializeField]
        private TransformVar _transform;
		
        [Tooltip("Point to look at.")]
        [SerializeField]
        private Vector3Var _worldPosition;
		
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
		
        public override bool CanExecute() => CheckParameters(_transform, _worldPosition, _smoothTime);

        public override void Execute()
        {
	        var transform = _transform.Value;
	        if (transform == null) return;
	        
            var lookAtPos = _worldPosition.Value;
            var diff = lookAtPos - _transform.Value.position;
            if (diff != Vector3.zero && diff.sqrMagnitude > 0)
            {
	            _desiredRotation = Quaternion.LookRotation(diff, _worldUp.IsNone ? Vector3.up : _worldUp.Value);
            }

            var currentRotation = transform.rotation;
            transform.rotation = SmoothLookAtHelper.Update(currentRotation, _desiredRotation, _smoothTime.Value, MaxSpeed.Value);
        }
		
        public override string GetSummary()
        {
	        var s = "{Transform} smooth look at {_worldPosition} in {_smoothTime}s";
	        if (MaxSpeed.Value > 0f) s += " max {MaxSpeed}°/s";
	        if (_worldUp.Value != Vector3.up) s += " ({_worldUp})";
	        return s;
        }    
    }
}