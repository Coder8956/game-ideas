using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ConvertibleGroup("FloatOp")]
    [ActionDescription("Normalizes a float value to be between 0 and 1 using a MaxValue. " +
                       "For example, if the MaxValue is 100 and the float is 50, the normalized value will be 0.5")]
    public class FloatNormalize : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The float to normalize.")]
        public FloatRef Float;

        [Tooltip("The maximum value, equivalent to 1 when normalized.")]
        public FloatVar MaxValue;

        public override bool CanExecute() => CheckParameters(Float, MaxValue);

        public override void Execute() => Float.Value = Mathf.Clamp01(Float.Value/ MaxValue.Value);

        public override string GetSummary() => "Normalize {Float} max: {MaxValue}";
    }
}