using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a String to an Integer.")]
    public sealed class ConvertStringToInteger : BaseAction
    {
        [ActionTarget]
        [Tooltip("The String to convert.")]
        [SerializeField]
        private StringRef _string;

        [Tooltip("Store the converted Integer value.")]
        [SerializeField, WriteOnly]
        private IntegerRef _integer;

        [Tooltip("Event sent if conversion succeeds.")]
        [SerializeField, OptionalField]
        private EventRef _successEvent;

        [Tooltip("Event sent if conversion fails.")]
        [SerializeField, OptionalField]
        private EventRef _failureEvent;

        public override bool CanExecute() => CheckParameters(_string, _integer);

        public override void Execute()
        {
            var text = _string.Value;
            if (string.IsNullOrEmpty(text))
            {
                SendEvent(_failureEvent);
                return;
            }

            var ok = int.TryParse(text, out var result);
            if (ok) _integer.Value = result;

            SendEvent(ok ? _successEvent : _failureEvent);
        }

        public override string GetSummary() => "Convert {_string} to int -> {_integer}";
    }
}