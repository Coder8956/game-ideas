using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.InputAxis)]
    [ActionDescription("Get a Vector2 from Horizontal and Vertical Input Axis." + Strings.LimitedAxisSupport)]
    public class InputGetAxisVector2 : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;
        
        [OptionalField]
        [DefaultValue("Horizontal")]
        [Tooltip("The name of the Horizontal Input Axis. " +
                 "\nSets the X value of the output Vector2.")]
        public StringVar HorizontalAxis;
        
        [OptionalField]
        [DefaultValue("Vertical")]
        [Tooltip("The name of the Vertical Input Axis. " +
                 "\nSets the Y value of the output Vector2.")]
        public StringVar VerticalAxis;

        [Tooltip("Clamp the input vector so that its magnitude is never greater than 1. " +
                 "<br/>E.g. so a diagonal input vector isn't larger than a horizontal or vertical input vector.")]
        [DefaultValue(true)]
        public BoolVar ClampInput;
        
        [DefaultValue(1f)]
        [Tooltip("Normally axis values are in the range -1 to 1. Use the multiplier to make this range bigger. " +
                 "<br/>E.g., A multiplier of 100 returns values from -100 to 100.")]
        public FloatVar Multiplier;
        
        [Header("Output")]
        
        [FormerlySerializedAs("Result")]
        [WriteOnly, OptionalField]
        [Tooltip("Store the result in a Vector2 variable.")]
        public Vector2Ref StoreVector;

        [WriteOnly, OptionalField]
        [Tooltip("Store the magnitude of the input in a float variable. " +
                 "This value is always between 0 and 1.")]
        public FloatRef StoreMagnitude;
        
        public override bool CanExecute() => true;

        public override void Execute()
        {
            // get individual axis
            // leaving an axis empty or set to None sets its value to 0

            var h = HorizontalAxis.HasValue() ? InputShim.GetAxis(HorizontalAxis.Value) : 0;
            var v = VerticalAxis.HasValue() ? InputShim.GetAxis(VerticalAxis.Value) : 0;
            var direction = new Vector2(h, v);
            if (ClampInput.Value)
            {
                direction = Vector2.ClampMagnitude(direction, 1);
            }

            if (StoreVector.IsAssigned) StoreVector.Value = direction * Multiplier.Value;
            if (StoreMagnitude.IsAssigned) StoreMagnitude.Value = direction.magnitude;
        }

        public override string GetSummary() => 
            "Get {HorizontalAxis}, {VerticalAxis} Axis " + 
            (Multiplier.IsNotDefault(1f) ? " x {Multiplier}" : "") +
            " {StoreVector:output} {StoreMagnitude:output}";
    }
}