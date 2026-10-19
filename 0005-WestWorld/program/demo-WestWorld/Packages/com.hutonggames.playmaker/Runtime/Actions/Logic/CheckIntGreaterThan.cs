using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckInt")]
    [ActionDescription("Check if an integer variable is greater than a given value.")]
    public class CheckIntGreaterThan : BaseTrueFalseAction
    {
        [Tooltip("The integer to check.")]
        public IntegerRef Integer;

        [Tooltip("The value to compare to.")]
        [ConvertibleName("Other")]
        public IntegerVar GreaterThan;
        
        protected override string TrueSummary => "{Integer} > {GreaterThan}";
        protected override string FalseSummary => "{Integer} <= {GreaterThan}";
        
        public override bool CanExecute() => CheckParameters(Integer, GreaterThan);

        protected override bool Test() => Integer.Value > GreaterThan.Value;
    }
}