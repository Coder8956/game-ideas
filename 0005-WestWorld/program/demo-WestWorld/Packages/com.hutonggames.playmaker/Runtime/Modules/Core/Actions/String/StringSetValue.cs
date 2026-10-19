using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.String)]
    [ActionDescription("Set a String variable's value.")]
    public class StringSetValue : BaseAction
    {
        [DefaultName("String")]
        [WriteOnly, ActionTarget]
        [Tooltip("The Variable to set.")]
        public StringRef Variable;

        [OptionalField, Expandable]
        [Tooltip("Set the Variable to this Value." +
                 "\n<b>Tip</b>: Enable Use Variable Tokens to insert values with {VariableName}.")]
        public StringVar Value;

        [Tooltip("Resolve {VariableName} and {VariableName.Property} tokens in the value.")]
        [DefaultValue(false)]
        public BoolVar UseVariableTokens;

        public override bool CanExecute() => !Variable.IsNone;

        public override void Execute() => Variable.Value = UseVariableTokens.Value
            ? DebugLogTextFormatter.Format(Value.Value, Fsm?.Variables)
            : Value.Value;

        public override string GetSummary() => "Set {Variable} to {Value}";
    }
}
