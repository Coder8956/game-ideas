using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckBool")]
    [ActionDescription("Check if a Bool variable is equal to a given value.")]
    public class CheckBoolEquals : BaseTrueFalseAction
    {
        [Tooltip("The Bool to check.")]
        public BoolRef Bool;

        [BoolVarDropdown]
        [Tooltip("The value to compare to.")]
        public BoolVar EqualTo;
        
        protected override string TrueSummary => "{Bool} == {EqualTo}";
        protected override string FalseSummary => "{Bool} != {EqualTo}";
        
        public override bool CanExecute() => CheckParameters(Bool, EqualTo);

        protected override bool Test() => Bool.Value == EqualTo.Value;
    }
}