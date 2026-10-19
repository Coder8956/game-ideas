using System;
using HutongGames.PlayMaker.SaveSystem;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Load all FSM variables and Global Variables from the chosen save profile.")]
    public sealed class LoadGame : BaseAction
    {
        [FormerlySerializedAs("_profileId")]
        [Tooltip("Optional save profile (save slot).\n" +
                 "If empty, uses the current profile.\n" +
                 "This maps to a JSON file in PlayMaker2/Save.")]
        [SerializeField, OptionalField]
        private StringVar _profile;

        public override void OnStart()
        {
            var profileId = string.IsNullOrWhiteSpace(_profile.Value)
                ? null
                : _profile.Value;

            SaveManager.LoadGame(profileId);
        }

        public override string GetSummary() => _profile.IsDefault() 
            ? "Load Game (Current Profile)" 
            : "Load Game from {_profile}";
    }
}