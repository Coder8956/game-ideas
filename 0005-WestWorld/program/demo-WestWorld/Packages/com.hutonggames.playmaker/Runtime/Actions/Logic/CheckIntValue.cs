using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckFloat")]
    [ActionDescription("Check an Integer value.")]
    public class CheckIntValue : BaseTrueFalseAction
    {
        [Tooltip("The Integer to check.")]
        public IntegerRef Integer;

        [Tooltip("The check to perform on the Integer.")]
        public NumericComparisonOperation Check;
        
        [Tooltip("The value to compare to.")]
        public IntegerVar Other;
        
        protected override string TrueSummary => "{Integer} is {Check} {Other}";
        protected override string FalseSummary => "{Integer} is not {Check} {Other}";
        
        public override bool CanExecute() => CheckParameters(Integer, Other);

        protected override bool Test() => Check.Evaluate(Integer.Value, Other.Value);
    }
}