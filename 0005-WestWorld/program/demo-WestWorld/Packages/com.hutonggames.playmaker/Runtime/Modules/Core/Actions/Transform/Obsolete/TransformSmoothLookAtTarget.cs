using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    
    [Obsolete("Use TransformLookAtTarget instead.")]
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("LookAt")]
    [ActionDescription("Smoothly rotates the transform so the forward vector points at target's current position.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.LookAt.html")]
    public class TransformSmoothLookAtTarget : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
        
        [OwnerDefaultValue]
        [Tooltip("The Transform to rotate.")]
        public TransformVar Transform;

        [Tooltip("The target to look at.")]
        public TransformVar Target;
        
        [VarSlider(0.01f, 1.0f), DefaultValue(0.3f)]
        [Tooltip("Smooth Time in seconds (roughly the time to halve the position error). Smaller = snappier.")]
        [SerializeField] private FloatVar _smoothTime;
        
        [FormerlySerializedAs("Speed")]
        [VarSlider(0, 1080)]
        [Tooltip("Optional max angular speed in degrees per second. 0 = uncapped.")]
        public FloatVar MaxSpeed;
        
        [Tooltip("Ignore any height differences between the target and the transform.")]
        public BoolVar IgnoreY;
        
        [DefaultValue("~Vector3Up")]
        [Tooltip("Vector specifying the upward direction.")]
        public Vector3Var WorldUp;
        
        private Quaternion _desiredRotation;
        
        public override bool CanExecute() => CheckParameters(Transform, Target, _smoothTime);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            
            var lookAtPos = Target.Value.position;
            if (IgnoreY.Value)
            {
                lookAtPos.y = transform.position.y;
            }
            
            var diff = lookAtPos - transform.position;
            if (diff != Vector3.zero && diff.sqrMagnitude > 0)
            {
                _desiredRotation = Quaternion.LookRotation(diff, WorldUp.IsNone ? Vector3.up : WorldUp.Value);
            }

            var currentRotation = transform.rotation;
            transform.rotation = SmoothLookAtHelper.Update(currentRotation, _desiredRotation, _smoothTime.Value, MaxSpeed.Value);
        }

        public override string GetSummary()
        {
            var s = "{Transform} smooth look at {Target} in {_smoothTime}s";
            if (MaxSpeed.Value > 0f) s += " max {MaxSpeed}°/s";
            if (WorldUp.Value != Vector3.up) s += " ({WorldUp})";
            return s;
        }
    }
}