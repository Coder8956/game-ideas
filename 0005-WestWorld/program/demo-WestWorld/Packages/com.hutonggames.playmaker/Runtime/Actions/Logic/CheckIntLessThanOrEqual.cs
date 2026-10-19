using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckInt")]
    [ActionDescription("Check if an integer variable is less than or equal to a given value.")]
    public class CheckIntLessThanOrEqual : BaseTrueFalseAction
    {
        [Tooltip("The integer to check.")]
        public IntegerRef Integer;

        [Tooltip("The value to compare to.")]
        [ConvertibleName("Other")]
        public IntegerVar LessThanOrEqual;
        
        protected override string TrueSummary => "{Integer} <= {LessThanOrEqual}";
        protected override string FalseSummary => "{Integer} > {LessThanOrEqual}";
        
        public override bool CanExecute() => CheckParameters(Integer, LessThanOrEqual);

        protected override bool Test() => Integer.Value <= LessThanOrEqual.Value;
    }
}