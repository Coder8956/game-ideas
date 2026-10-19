using System;
using HutongGames.PlayMaker.SaveSystem;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Set the global save profile used by all FSMs and global variables. " +
                       "\nNOTE: Auto-save always saves to the current profile.")]
    [MovedFrom(true, null, null, "SetSaveProfileId")]
    public sealed class SetSaveProfile : BaseAction
    {
        [FormerlySerializedAs("_profileId")]
        [Tooltip("Profile to use for saving and loading.\n" +
                 "This maps directly to a JSON file name in the `PlayMaker2/Save` folder.")]
        [SerializeField, DefaultValue("Default")]
        private StringVar _profile;

        [Tooltip("If enabled, delete any existing save file for this profile on enter.")]
        [SerializeField]
        private BoolVar _deleteExistingFile;

        public override void OnStart()
        {
            var id = _profile.Value;

            if (string.IsNullOrWhiteSpace(id))
            {
                // Fall back to the default profile
                id = "Default";
            }

            SaveManager.SetCurrentProfile(id, _deleteExistingFile.Value);

            Finish();
        }

        public override string GetSummary() => 
            "Set Save Profile to {_profile} " +
            (_deleteExistingFile.IsNotDefault() ? "({_deleteExistingFile})" : "");
    }
}
