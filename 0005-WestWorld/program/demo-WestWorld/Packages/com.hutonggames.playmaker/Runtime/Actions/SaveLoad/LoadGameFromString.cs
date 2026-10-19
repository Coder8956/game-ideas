using System;
using HutongGames.PlayMaker.SaveSystem;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Load all FSM variables and Global Variables from a JSON string without reading a save file from disk.")]
    public sealed class LoadGameFromString : BaseAction
    {
        [Tooltip("Save JSON string to load.")]
        [SerializeField]
        private StringRef _json;

        [Tooltip("Optional save profile (save slot).\n" +
                 "If empty, uses the current profile.")]
        [SerializeField, OptionalField]
        private StringVar _profile;

        [ActionHeader("Output")]

        [Tooltip("Set to true if the save JSON was loaded.")]
        [SerializeField, OptionalField, WriteOnly]
        private BoolRef _success;

        [ActionHeader("Events")]

        [Tooltip("Event to send if the save JSON was loaded.")]
        [SerializeField, OptionalField]
        private EventRef _successEvent;

        [Tooltip("Event to send if the save JSON could not be loaded.")]
        [SerializeField, OptionalField]
        private EventRef _failureEvent;

        public override bool CanExecute() => _json != null && !_json.IsNone;

        public override void OnStart()
        {
            var profileId = string.IsNullOrWhiteSpace(_profile.Value)
                ? null
                : _profile.Value;

            var success = SaveManager.LoadGameFromString(_json.Value, profileId);

            if (_success.IsAssigned)
                _success.Value = success;

            SendEvent(success ? _successEvent : _failureEvent);
            Finish();
        }

        public override string GetSummary() =>
            _profile.IsDefault()
                ? "Load Game from String (Current Profile)"
                : "Load Game from String ({_profile})";
    }
}
