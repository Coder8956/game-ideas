using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.InputAxis)]
    [Tooltip("Gets the value of an Input Axis and stores it in a float variable." + Strings.LimitedAxisSupport)]
    public class InputGetAxisFloat : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [DefaultValue("Horizontal")]
        [Tooltip("The name of the Input Axis to read. Defined in the Unity Input Manager.")]
        public StringVar InputAxis;
        
        [DefaultValue(1f)]
        [Tooltip("Normally axis values are in the range -1 to 1. Use the multiplier to make this range bigger. " +
                 "E.g., A multiplier of 100 returns values from -100 to 100.")]
        public FloatVar Multiplier;

        [Tooltip("Invert the input value. E.g., -1 becomes 1, and 1 becomes -1.")]
        public BoolVar Invert;
        
        [WriteOnly] 
        [Tooltip("Store the input in a float variable.")]
        public FloatRef Result;

        public override bool CanExecute() => InputAxis.HasValue() && !Result.IsNoneOrNull;

        public override void Execute()
        {
            var input = InputShim.GetAxis(InputAxis.Value) * Multiplier.Value;
            if (Invert.Value) input = -input;
            Result.Value = input;
        }
        
        public override string GetSummary() => 
            "Get {InputAxis} Axis" + 
            (Multiplier.IsNotDefault(1f) ? " * {Multiplier}" : "") + 
            " -> {Result}";
    }
}