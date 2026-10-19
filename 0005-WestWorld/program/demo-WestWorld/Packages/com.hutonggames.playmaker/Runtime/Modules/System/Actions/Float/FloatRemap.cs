using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ConvertibleGroup("FloatOp")]
    [ActionDescription("Remaps a float value from one range to another. " +
                       "For example, remap 50 from [0,100] to [0,1] gives 0.5.")]
    [System.Serializable]
    public sealed class FloatRemap : BaseAction
    {
        [ActionTarget]
        [Tooltip("The float value to remap. If Output is not set, the remapped value is written back to this variable.")]
        public FloatRef Float;

        [WriteOnly, OptionalField]
        [Tooltip("Optional variable to store the remapped value. If not set, the remapped value is written back to Float.")]
        public FloatRef Output;

        [Header("From Range")]

        [Tooltip("Minimum value of the input range.")]
        public FloatVar FromMin;

        [Tooltip("Maximum value of the input range.")]
        [DefaultValue(1f)]
        public FloatVar FromMax;

        [Header("To Range")]

        [Tooltip("Minimum value of the output range.")]
        public FloatVar ToMin;

        [Tooltip("Maximum value of the output range.")]
        [DefaultValue(1f)]
        public FloatVar ToMax;

        [Tooltip("If true, clamp the input to the [FromMin, FromMax] range before remapping.")]
        public BoolVar Clamp;

        public override bool CanExecute()
        {
            return CheckParameters(Float, FromMin, FromMax, ToMin, ToMax);
        }

        public override void Execute()
        {
            var fromMin = FromMin.Value;
            var fromMax = FromMax.Value;
            var toMin   = ToMin.Value;
            var toMax   = ToMax.Value;

            // Avoid divide by zero
            if (Mathf.Approximately(fromMax, fromMin))
                return;

            var value = Float.Value;

            if (Clamp.Value)
            {
                value = Mathf.Clamp(value, fromMin, fromMax);
            }

            var t = (value - fromMin) / (fromMax - fromMin);     // normalized 0–1
            var remapped = Mathf.Lerp(toMin, toMax, t);

            if (Output != null && Output.IsAssigned)
            {
                Output.Value = remapped;
            }
            else
            {
                Float.Value = remapped;
            }
        }

        public override string GetSummary()
        {
            return Output != null && Output.IsAssigned
                ? "Remap {Float} [{FromMin}, {FromMax}] → [{ToMin}, {ToMax}] -> {Output}"
                : "Remap {Float} [{FromMin}, {FromMax}] → [{ToMin}, {ToMax}]";
        }
    }
}
