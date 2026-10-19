using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.InputAxis)]
    [ActionDescription("Get a Vector3 from Horizontal and Vertical Input Axis." + Strings.LimitedAxisSupport)]
    public class InputGetAxisVector3 : BaseAction
    {
        public enum AxisPlane
        {
            XZ,
            XY,
            YZ
        }
        
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [OptionalField]
        [DefaultValue("Horizontal")]
        [Tooltip("The name of the Horizontal Input Axis.")]
        public StringVar HorizontalAxis;
        
        [OptionalField]
        [DefaultValue("Vertical")]
        [Tooltip("The name of the Vertical Input Axis.")]
        public StringVar VerticalAxis;

        [Tooltip("Clamp the input vector so that its magnitude is never greater than 1. " +
                 "<br/>E.g. so a diagonal input vector isn't larger than a horizontal or vertical input vector.")]
        [DefaultValue(true)]
        public BoolVar ClampInput;
        
        [DefaultValue(1f)]
        [Tooltip("Normally axis values are in the range -1 to 1. Use the multiplier to make this range bigger. " +
                 "<br/>E.g., A multiplier of 100 returns values from -100 to 100.")]
        public FloatVar Multiplier;
        
        [ActionHeader("Space")]
        
        [Tooltip("Sets the world axis the input maps to. The remaining axis will be set to zero.")]
        public AxisPlane MapToPlane;
        
        [OptionalField]
        [Tooltip("Optionally calculate a vector relative to a GameObject. " +
                 "E.g., The camera for third person movement.")]
        public GameObjectVar RelativeTo;
        
        [ActionHeader("Output")]
        
        [FormerlySerializedAs("Result")]
        [WriteOnly, OptionalField]
        [Tooltip("Store the result in a Vector3 variable.")]
        public Vector3Ref StoreVector;

        [WriteOnly, OptionalField]
        [Tooltip("Store the magnitude of the input in a float variable. " +
                 "This value is always between 0 and 1.")]
        public FloatRef StoreMagnitude;
        
        public override bool CanExecute() => true;

        public override void Execute()
        {
            // Get space to move in
            
            var forward = new Vector3();
            var right = new Vector3();
			
            if (RelativeTo.Value == null)
            {
                switch (MapToPlane) 
                {
                    case AxisPlane.XZ:
                        forward = Vector3.forward;
                        right = Vector3.right;
                        break;
					
                    case AxisPlane.XY:
                        forward = Vector3.up;
                        right = Vector3.right;
                        break;
					
                    case AxisPlane.YZ:
                        forward = Vector3.up;
                        right = Vector3.forward;
                        break;
                }
            }
            else
            {
                var transform = RelativeTo.Value.transform;
				
                switch (MapToPlane) 
                {
                    case AxisPlane.XZ:
                        forward = transform.TransformDirection(Vector3.forward);
                        forward.y = 0;
                        forward = forward.normalized;
                        right = new Vector3(forward.z, 0, -forward.x);
                        break;
					
                    case AxisPlane.XY:
                    case AxisPlane.YZ:
                        // NOTE: in relative mode XY and YZ are the same!
                        forward = Vector3.up;
                        forward.z = 0;
                        forward = forward.normalized;
                        right = transform.TransformDirection(Vector3.right);
                        break;
                }
				
                // Right vector relative to the object
                // Always orthogonal to the forward vector
				
            }
            
            // get individual axis
            // leaving an axis empty or set to None sets its value to 0

            var h = HorizontalAxis.HasValue() ? InputShim.GetAxis(HorizontalAxis.Value) : 0;
            var v = VerticalAxis.HasValue() ? InputShim.GetAxis(VerticalAxis.Value) : 0;
            
            // calculate resulting direction vector

            var direction = h * right + v * forward;
            if (ClampInput.Value)
            {
                direction = Vector3.ClampMagnitude(direction, 1);
            }
            
            if (StoreVector.IsAssigned) StoreVector.Value = direction * Multiplier.Value;
            if (StoreMagnitude.IsAssigned) StoreMagnitude.Value = direction.magnitude;
        }
        
        public override string GetSummary() => 
            "Get {HorizontalAxis}, {VerticalAxis} Axis " +
            (Multiplier.IsNotDefault(1f) ? " * {Multiplier}" : "") + 
            " {StoreVector:output} {StoreMagnitude:output}";
    }
}