using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert any Variable value to a String.")]
    public sealed class ConvertVariableToString : BaseAction
    {
        [ActionTarget]
        [SerializeReference]
        [BaseType(typeof(object))]
        [Tooltip("The Variable to convert.")]
        private AnyVariableRef _variable;

        [Tooltip("Store the converted String value.")]
        [SerializeField, WriteOnly]
        private StringRef _string;

        public override bool CanExecute() => !_variable.IsNone && CheckParameters(_string);

        public override void Execute()
        {
            // Use the same rules as debug output (handles Unity null, collections, etc.)
            _string.Value = DebugUtility.GetDebugString(_variable.Value);
        }

        public override string GetSummary() => "Convert {_variable} to string -> {_string}";
    }
}