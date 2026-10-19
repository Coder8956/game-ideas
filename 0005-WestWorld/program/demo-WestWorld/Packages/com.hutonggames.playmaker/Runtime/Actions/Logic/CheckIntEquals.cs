using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckInt")]
    [ActionDescription("Check if an integer variable is equal to a given value.")]
    public class CheckIntEquals : BaseTrueFalseAction
    {
        [Tooltip("The integer to check.")]
        public IntegerRef Integer;

        [Tooltip("The value to compare to.")]
        [ConvertibleName("Other")]
        public IntegerVar EqualTo;
        
        protected override string TrueSummary => "{Integer} == {EqualTo}";
        protected override string FalseSummary => "{Integer} != {EqualTo}";
        
        public override bool CanExecute() => CheckParameters(Integer, EqualTo);

        protected override bool Test() => Integer.Value == EqualTo.Value;
    }
}