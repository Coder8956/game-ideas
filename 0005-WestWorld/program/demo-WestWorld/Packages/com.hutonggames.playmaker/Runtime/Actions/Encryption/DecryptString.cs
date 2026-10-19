using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.Encryption)]
    [ActionDescription("Decrypt a string created with Encrypt String. Useful for loading encrypted save data from LoadGameFromString.")]
    public sealed class DecryptString : BaseAction
    {
        [ActionTarget]
        [Tooltip("The encrypted string to decrypt.")]
        [SerializeField]
        private StringVar _encryptedString;

        [Tooltip("Passphrase used to decrypt the string. This must match the passphrase used to encrypt it.")]
        [SerializeField]
        private StringVar _passphrase;

        [ActionHeader("Output")]

        [Tooltip("Store the decrypted string.")]
        [SerializeField, WriteOnly]
        private StringRef _storeString;

        [Tooltip("Set to true if the string was decrypted.")]
        [SerializeField, OptionalField, WriteOnly]
        private BoolRef _success;

        [ActionHeader("Events")]

        [Tooltip("Event to send if the string was decrypted.")]
        [SerializeField, OptionalField]
        private EventRef _successEvent;

        [Tooltip("Event to send if the string could not be decrypted.")]
        [SerializeField, OptionalField]
        private EventRef _failureEvent;

        public override bool CanExecute() => CheckParameters(_encryptedString, _passphrase, _storeString);

        public override void Execute()
        {
            var success = StringEncryptionUtility.TryDecrypt(_encryptedString.Value, _passphrase.Value, out var text);

            _storeString.Value = text;

            if (_success.IsAssigned)
                _success.Value = success;

            SendEvent(success ? _successEvent : _failureEvent);
            Finish();
        }

        public override string GetSummary() => "Decrypt {_encryptedString} -> {_storeString}";
    }
}
