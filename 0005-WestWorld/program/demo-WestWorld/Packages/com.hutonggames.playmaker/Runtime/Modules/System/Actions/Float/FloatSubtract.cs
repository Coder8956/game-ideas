using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ConvertibleGroup("FloatOp")]
    [ActionDescription("Subtract from a float variable value.")]
    public class FloatSubtract : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The float to subtract from.")]
        public FloatRef Float;

        [Tooltip("The value to subtract." + Strings.PerSecondNote)]
        public FloatVar Subtract;

        public override bool CanUsePerSecond => true;
        
        public override bool CanExecute() => CheckParameters(Float, Subtract);

        public override void Execute() => Float.Value -= Subtract.Value * PerSecond;

        public override string GetSummary() => "Subtract {Subtract} from {Float} {PerSecond}";
    }
}