using System;
using HutongGames.PlayMaker.SaveSystem;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Save all FSM variables and Global Variables to the chosen save profile.")]
    public sealed class SaveGame : BaseAction
    {
        [FormerlySerializedAs("_profileId")]
        [Tooltip("Optional save profile (save slot).\n" +
                 "If empty, uses the current profile.\n" +
                 "This maps to a JSON file in PlayMaker2/Save.")]
        [SerializeField, OptionalField]
        private StringVar _profile;

        public override void OnStart()
        {
            // Treat empty / None as "use current profile"
            var profileId = string.IsNullOrWhiteSpace(_profile.Value)
                ? null
                : _profile.Value;

            SaveManager.SaveGame(profileId);

            Finish();
        }

        public override string GetSummary() => _profile.IsDefault() 
            ? "Save Game (Current Profile)" 
            : "Save Game to {_profile}";
    }
}