using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ConvertibleGroup("CheckString")]
    [ActionDescription("Check a string value against a condition.")]
    public class CheckString : BaseTrueFalseAction
    {
        [Tooltip("The String variable to check.")]
        public StringRef String;

        [MatchType(nameof(String))]
        [Tooltip(Strings.ConditionTest)]
        public ConditionTest CheckIf = new ();
        
        public override bool CanExecute() => CheckParameters(String);

        protected override string TrueSummary => "{String} {CheckIf}";
        protected override string FalseSummary => "{String} not {CheckIf}";
        
        protected override bool Test() => CheckIf.Evaluate(String.Value);
    }
}
