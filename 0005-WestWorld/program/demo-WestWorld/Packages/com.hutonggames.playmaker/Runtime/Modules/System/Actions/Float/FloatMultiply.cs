using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ConvertibleGroup("FloatOp")]
    [ActionDescription("Multiply a float by another float.")]
    public class FloatMultiply : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The first float.")]
        public FloatRef Float;

        [Tooltip("The second float.")]
        public FloatVar Multiply;

        public override bool CanExecute() => CheckParameters(Float, Multiply);

        public override void Execute() => Float.Value *= Multiply.Value;

        public override string GetSummary() => "Multiply {Float} by {Multiply}";
    }
}