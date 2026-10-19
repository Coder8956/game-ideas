using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Encryption)]
    [ActionDescription("Encrypt a string with a passphrase. Useful for hiding save data from casual editing; do not store secrets in the client.")]
    public sealed class EncryptString : BaseAction
    {
        [ActionTarget]
        [Tooltip("The string to encrypt.")]
        [SerializeField]
        private StringVar _string;

        [Tooltip("Passphrase used to encrypt the string. The same passphrase is required to decrypt it.")]
        [SerializeField]
        private StringVar _passphrase;

        [ActionHeader("Output")]

        [Tooltip("Store the encrypted string.")]
        [SerializeField, WriteOnly]
        private StringRef _storeEncryptedString;

        [Tooltip("Set to true if the string was encrypted.")]
        [SerializeField, OptionalField, WriteOnly]
        private BoolRef _success;

        [ActionHeader("Events")]

        [Tooltip("Event to send if the string was encrypted.")]
        [SerializeField, OptionalField]
        private EventRef _successEvent;

        [Tooltip("Event to send if the string could not be encrypted.")]
        [SerializeField, OptionalField]
        private EventRef _failureEvent;

        public override bool CanExecute() => CheckParameters(_string, _passphrase, _storeEncryptedString);

        public override void Execute()
        {
            var success = StringEncryptionUtility.TryEncrypt(_string.Value, _passphrase.Value, out var encrypted);

            _storeEncryptedString.Value = encrypted;

            if (_success.IsAssigned)
                _success.Value = success;

            SendEvent(success ? _successEvent : _failureEvent);
            Finish();
        }

        public override string GetSummary() => "Encrypt {_string} -> {_storeEncryptedString}";
    }
}
