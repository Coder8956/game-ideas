using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicValue)]
    [ActionDescription("Check if a variable is equal to a given value.")]
    public class CheckVariableEquals : BaseTrueFalseAction
    {
        [SerializeReference]
        [BaseType(typeof(object))]
        [Tooltip("The Variable to check.")]
        public AnyVariableRef Variable;
        
        [SerializeReference]
        [MatchType(nameof(Variable)), CanBeNullOrEmpty]
        [Tooltip("Check if the Variable is equal to this value.")]
        public IVariableVar Value;

        public override bool CanExecute() => !Variable.IsNone;

        protected override bool Test()
        {
            return ValueHelper.ValuesEqual(Value.GetValue(), Variable.GetValue());
        }

        protected override string TrueSummary => "{Variable} == {Value}";
        protected override string FalseSummary => "{Variable} != {Value}";
    }
}
