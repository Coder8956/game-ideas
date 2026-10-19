using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Float)]
    [ConvertibleGroup("FloatOp")]
    [ActionDescription("Add to a float variable value.")]
    public class FloatAdd : BaseAction
    {
        [ActionTarget, WriteOnly]
        [Tooltip("The float to add to.")]
        public FloatRef Float;

        [Tooltip("The value to add." + Strings.PerSecondNote)]
        public FloatVar Add;

        public override bool CanUsePerSecond => true;
        
        public override bool CanExecute() => CheckParameters(Float, Add);

        public override void Execute() => Float.Value += Add.Value * PerSecond;

        public override string GetSummary() => "Add {Add} to {Float} {PerSecond}";
    }
}