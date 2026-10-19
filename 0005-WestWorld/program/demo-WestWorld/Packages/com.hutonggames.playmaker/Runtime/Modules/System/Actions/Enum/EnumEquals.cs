using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Enum)]
    [ActionDescription("Test if an Enum variable equals a given value.")]
    public class EnumEquals : BaseAction
    {
        [WriteOnly, ActionTarget]
        [Tooltip("The variable to check.")]
        public EnumRef Variable;
        
        [MatchType(nameof(Variable))]
        [Tooltip("Check if the variable has this value.")]
        public EnumVar Value;

        [Tooltip("Store the result in a Bool Variable.")]
        public BoolRef Result;
        
        public override bool CanExecute() => CheckParameters(Variable, Value, Result);

        public override void Execute() => Result.Value = Equals(Variable.Value, Value.Value);

        public override string GetSummary() => "{Variable} equals {Value} -> {Result}";
    }
}