using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ActionDescription("Check a variable's value against a condition.")]
    public class CheckVariable : BaseTrueFalseAction
    {
        [SerializeReference]
        [BaseType(typeof(object))]
        [Tooltip("The Variable to check.")]
        public AnyVariableRef Variable;
        
        [MatchType(nameof(Variable))]
        [Tooltip("The condition to test for.")]
        public ConditionTest CheckIf;
        
        protected override string TrueSummary => "{Variable} {CheckIf}";
        protected override string FalseSummary => "{Variable} not {CheckIf}";

        public override bool CanExecute() => !Variable.IsNone && CheckParameters(CheckIf);

        protected override bool Test() => CheckIf.Evaluate(Variable.GetValue());
    }
}