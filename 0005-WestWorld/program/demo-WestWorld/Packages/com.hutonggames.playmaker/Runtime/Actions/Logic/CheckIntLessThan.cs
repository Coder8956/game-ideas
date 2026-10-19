using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckInt")]
    [ActionDescription("Check if an integer variable is less than a given value.")]
    public class CheckIntLessThan : BaseTrueFalseAction
    {
        [Tooltip("The integer to check.")]
        public IntegerRef Integer;

        [Tooltip("The value to compare to.")]
        [ConvertibleName("Other")]
        public IntegerVar LessThan;
        
        protected override string TrueSummary => "{Integer} < {LessThan}";
        protected override string FalseSummary => "{Integer} >= {LessThan}";
        
        public override bool CanExecute() => CheckParameters(Integer, LessThan);

        protected override bool Test() => Integer.Value < LessThan.Value;
    }
}