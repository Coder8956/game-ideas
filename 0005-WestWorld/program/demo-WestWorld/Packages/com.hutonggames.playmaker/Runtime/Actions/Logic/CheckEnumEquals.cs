using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckEnum")]
    [ActionDescription("Check if an Enum variable is equal to a given value.")]
    public class CheckEnumEquals : BaseTrueFalseAction
    {
        [Tooltip("The Enum to check.")]
        public EnumRef Enum;

        [MatchType(nameof(Enum))]
        [Tooltip("The value to compare to.")]
        [ConvertibleName("Other")]
        public EnumVar EqualTo;
        
        protected override string TrueSummary => "{Enum} == {EqualTo}";
        protected override string FalseSummary => "{Enum} != {EqualTo}";
        
        public override bool CanExecute() => CheckParameters(Enum, EqualTo);

        protected override bool Test() => Equals(Enum.Value, EqualTo.Value);
    }
}