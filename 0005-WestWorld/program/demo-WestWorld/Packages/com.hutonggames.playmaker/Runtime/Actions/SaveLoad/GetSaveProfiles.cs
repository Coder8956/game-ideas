using System;
using HutongGames.PlayMaker.SaveSystem;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.SaveSystem)]
    [ActionDescription("Get all existing save profiles (save slots) found on disk.")]
    public sealed class GetSaveProfiles : BaseAction
    {
        [Tooltip("List variable to store all found save profiles.\n" +
                 "Profiles are derived from JSON file names in the PlayMaker2/Save folder.")]
        [SerializeField, WriteOnly]
        private StringListRef _profiles;

        public override void OnStart()
        {
            var profiles = SaveManager.GetExistingProfiles();

            if (_profiles == null)
            {
#if UNITY_EDITOR
                Debug.LogWarning("[PlayMaker Save] GetSaveProfiles: Profiles list variable is not set.");
#endif
                Finish();
                return;
            }
            
            _profiles.Value.Clear();
            _profiles.Value.AddRange(profiles);

            Finish();
        }

        public override string GetSummary() => "Get save profiles -> {_profiles}";
    }
}
