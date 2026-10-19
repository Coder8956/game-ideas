using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckFloat")]
    [ActionDescription("Check if a Float variable is greater than a given value.")]
    public class CheckFloatGreaterThan : BaseTrueFalseAction
    {
        [Tooltip("The Float to check.")]
        public FloatRef Float;

        [Tooltip("The value to compare to.")]
        [ConvertibleName("Other")]
        public FloatVar GreaterThan;
        
        protected override string TrueSummary => "{Float} > {GreaterThan}";
        protected override string FalseSummary => "{Float} <= {GreaterThan}";
        
        public override bool CanExecute() => CheckParameters(Float, GreaterThan);

        protected override bool Test() => Float.Value > GreaterThan.Value;
    }
}