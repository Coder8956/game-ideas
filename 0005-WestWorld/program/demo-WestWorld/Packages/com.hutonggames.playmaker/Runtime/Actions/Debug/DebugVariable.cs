using HutongGames;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Debug)]
    [ActionDescription("Display a variable on a debug panel while this action is active.")]
    public sealed class DebugVariable : BaseDebugAction
    {
        [ActionTarget]
        [SerializeReference]
        [BaseType(typeof(object))]
        [Tooltip("The variable to display while this action is active.")]
        private AnyVariableRef _variable;

        [OptionalField]
        [Tooltip("Optional label to show before the variable value. Leave empty to use the variable name.")]
        [SerializeField]
        private StringVar _label;

        public override void Reset()
        {
            _variable = new AnyVariableRef();
            _label = new StringVar();
            DebugDisplay = new DebugDisplay();
        }

        public override bool CanExecute() => _variable is { IsNone: false };

        public override void Execute()
        {
            if (Label == null) return;

            var labelText = _label?.HasValue(true) == true
                ? _label.Value
                : _variable.VariableShortName;

            var valueText = DebugUtility.GetStableString(_variable.GetValue());
            Label.text = string.IsNullOrEmpty(labelText)
                ? valueText
                : $"{labelText}: {valueText}";
        }

        public override string GetSummary() => "Debug {_variable}";
    }
}
