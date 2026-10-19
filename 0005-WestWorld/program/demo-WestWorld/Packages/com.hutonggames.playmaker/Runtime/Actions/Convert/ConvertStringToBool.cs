using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a String to a Bool.")]
    public sealed class ConvertStringToBool : BaseAction
    {
        [ActionTarget]
        [Tooltip("The String to convert.<br/>" + Strings.FlexibleBoolParsing)]
        [SerializeField]
        private StringRef _string;

        [Tooltip("Store the converted Bool value.")]
        [SerializeField, WriteOnly]
        private BoolRef _bool;

        [Tooltip("Event sent if conversion succeeds.")]
        [SerializeField, OptionalField]
        private EventRef _successEvent;

        [Tooltip("Event sent if conversion fails.")]
        [SerializeField, OptionalField]
        private EventRef _failureEvent;

        public override bool CanExecute() => CheckParameters(_string, _bool);

        public override void Execute()
        {
            var text = _string.Value;

            if (string.IsNullOrWhiteSpace(text))
            {
                SendEvent(_failureEvent);
                return;
            }
            
            var ok = BoolParser.TryParseFlexible(text.Trim(), out var result);
            if (ok) _bool.Value = result;
            SendEvent(ok ? _successEvent : _failureEvent);
        }

        public override string GetSummary() => "Convert {_string} to bool -> {_bool}";
    }
}
