using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckInt")]
    [ActionDescription("Check if an integer variable is greater than or equal to a given value.")]
    public class CheckIntGreaterThanOrEqual : BaseTrueFalseAction
    {
        [Tooltip("The integer to check.")]
        public IntegerRef Integer;

        [Tooltip("The value to compare to.")]
        [ConvertibleName("Other")]
        public IntegerVar GreaterThanOrEqual;
        
        protected override string TrueSummary => "{Integer} >= {GreaterThanOrEqual}";
        protected override string FalseSummary => "{Integer} < {GreaterThanOrEqual}";
        
        public override bool CanExecute() => CheckParameters(Integer, GreaterThanOrEqual);

        protected override bool Test() => Integer.Value >= GreaterThanOrEqual.Value;
    }
}