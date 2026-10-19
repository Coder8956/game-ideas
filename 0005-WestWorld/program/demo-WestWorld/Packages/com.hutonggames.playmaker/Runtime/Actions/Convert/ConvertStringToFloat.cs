using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Convert)]
    [ActionDescription("Convert a String to a Float.")]
    public sealed class ConvertStringToFloat : BaseAction
    {
        [ActionTarget]
        [Tooltip("The String to convert.")]
        [SerializeField]
        private StringRef _string;

        [Tooltip("Store the converted Float value.")]
        [SerializeField, WriteOnly]
        private FloatRef _float;

        [Tooltip("Event sent if conversion succeeds.")]
        [SerializeField, OptionalField]
        private EventRef _successEvent;

        [Tooltip("Event sent if conversion fails.")]
        [SerializeField, OptionalField]
        private EventRef _failureEvent;

        public override bool CanExecute() => CheckParameters(_string, _float);

        public override void Execute()
        {
            var text = _string.Value;
            if (string.IsNullOrEmpty(text))
            {
                SendEvent(_failureEvent);
                return;
            }

            var ok = float.TryParse(text, out var result);
            if (ok) _float.Value = result;

            SendEvent(ok ? _successEvent : _failureEvent);
        }

        public override string GetSummary() => "Convert {_string} to float -> {_float}";
    }
}
