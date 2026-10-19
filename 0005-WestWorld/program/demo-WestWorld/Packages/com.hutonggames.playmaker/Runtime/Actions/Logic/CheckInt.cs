using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckInt")]
    [ActionDescription("Check an integer value against a condition.")]
    public class CheckInt : BaseTrueFalseAction
    {
        [Tooltip("The Integer variable to check.")]
        public IntegerRef Integer;

        [MatchType(nameof(Integer))]
        [Tooltip(Strings.ConditionTest)]
        public ConditionTest CheckIf = new ();
        
        public override bool CanExecute() => CheckParameters(Integer);

        protected override string TrueSummary => "{Integer} {CheckIf}";
        protected override string FalseSummary => "{Integer} not {CheckIf}";
        
        protected override bool Test() => CheckIf.Evaluate(Integer.Value);
    }
}
