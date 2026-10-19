using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckFloat")]
    [ActionDescription("Check if a Float variable is greater than or equal to a given value.")]
    public class CheckFloatGreaterThanOrEqual : BaseTrueFalseAction
    {
        [Tooltip("The Float to check.")]
        public FloatRef Float;

        [Tooltip("The value to compare to.")]
        [ConvertibleName("Other")]
        public FloatVar GreaterThanOrEqual;
        
        protected override string TrueSummary => "{Float} >= {GreaterThanOrEqual}";
        protected override string FalseSummary => "{Float} < {GreaterThanOrEqual}";
        
        public override bool CanExecute() => CheckParameters(Float, GreaterThanOrEqual);

        protected override bool Test() => Float.Value >= GreaterThanOrEqual.Value;
    }
}