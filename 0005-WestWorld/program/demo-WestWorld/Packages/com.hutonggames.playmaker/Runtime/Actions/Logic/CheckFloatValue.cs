using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckFloat")]
    [ActionDescription("Check a Float value.")]
    public class CheckFloatValue : BaseTrueFalseAction
    {
        [Tooltip("The Float to check.")]
        public FloatRef Float;

        [Tooltip("The check to perform on the Float.")]
        public NumericComparisonOperation Check;
        
        [Tooltip("The value to compare to.")]
        public FloatVar Other;
        
        protected override string TrueSummary => "{Float} is {Check} {Other}";
        protected override string FalseSummary => "{Float} is not {Check} {Other}";
        
        public override bool CanExecute() => CheckParameters(Float, Other);

        protected override bool Test() => Check.Evaluate(Float.Value, Other.Value);
    }
}