using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.String)]
    [ActionDescription("Set a String variable to the True Value or False Value based on a Bool.")]
    public class StringSelectValue : BaseSelectValue<StringVar, StringRef>
    {
        [Tooltip("Resolve {VariableName} and {VariableName.Property} tokens in the selected value.")]
        [DefaultValue(false)]
        public BoolVar UseVariableTokens;

        public override void Reset()
        {
            base.Reset();
            SetDefaults("True", "False");
        }

        public override void Execute()
        {
            var value = Evaluate.GetValue() as string;
            var useVariableTokens = UseVariableTokens is { Value: true };
            Variable.SetValue(useVariableTokens
                ? DebugLogTextFormatter.Format(value, Fsm?.Variables)
                : value);
        }
    }
}
