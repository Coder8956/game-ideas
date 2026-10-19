using System;
using HutongGames.PlayMaker.SaveSystem;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Save all FSM variables and Global Variables to a JSON string without writing a save file to disk.")]
    public sealed class SaveGameToString : BaseAction
    {
        [Tooltip("Optional save profile (save slot).\n" +
                 "If empty, uses the current profile.")]
        [SerializeField, OptionalField]
        private StringVar _profile;

        [ActionHeader("Output")]

        [Tooltip("Store the save JSON string.")]
        [SerializeField, WriteOnly]
        private StringRef _storeJson;

        [Tooltip("Set to true if the save JSON was created.")]
        [SerializeField, OptionalField, WriteOnly]
        private BoolRef _success;

        [ActionHeader("Events")]

        [Tooltip("Event to send if the save JSON was created.")]
        [SerializeField, OptionalField]
        private EventRef _successEvent;

        [Tooltip("Event to send if the save JSON could not be created.")]
        [SerializeField, OptionalField]
        private EventRef _failureEvent;

        public override bool CanExecute() => CheckParameters(_storeJson);

        public override void OnStart()
        {
            var profileId = string.IsNullOrWhiteSpace(_profile.Value)
                ? null
                : _profile.Value;

            var json = SaveManager.SaveGameToString(profileId);
            var success = !string.IsNullOrEmpty(json);

            _storeJson.Value = json;

            if (_success.IsAssigned)
                _success.Value = success;

            SendEvent(success ? _successEvent : _failureEvent);
            Finish();
        }

        public override string GetSummary() =>
            _profile.IsDefault()
                ? "Save Game to String (Current Profile) -> {_storeJson}"
                : "Save Game to String ({_profile}) -> {_storeJson}";
    }
}
