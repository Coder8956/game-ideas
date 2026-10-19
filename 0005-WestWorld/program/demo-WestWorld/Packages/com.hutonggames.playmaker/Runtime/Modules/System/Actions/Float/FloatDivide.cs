using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ConvertibleGroup("FloatOp")]
    [ActionDescription("Divides a float by another float.")]
    public class FloatDivide : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The first float.")]
        public FloatRef Float;

        [Tooltip("The second float.")]
        public FloatVar Divide;

        public override bool CanExecute() => CheckParameters(Float, Divide);

        public override void Execute() => Float.Value /= Divide.Value;

        public override string GetSummary() => "Divide {Float} by {Divide}";
    }
}