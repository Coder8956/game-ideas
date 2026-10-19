using System;
using HutongGames.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Checks if an asset exists in a Resources folder (by attempting to load it).")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Resources.Load.html")]
    public sealed class ResourcesCheckAssetExists : BaseTrueFalseAction
    {
        [Tooltip("Path to the target resource (relative to a Resources folder, without extension).")]
        [SerializeField]
        private StringVar _path;

        [BaseType(typeof(Object))]
        [Tooltip("The type of asset to check for.")]
        [SerializeField]
        private TypeReference _type;

        [Tooltip("Unload the asset after checking (recommended). Not supported for GameObjects/Components/AssetBundles.")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _unloadAssetAfterCheck;

        protected override bool Test()
        {
            if (string.IsNullOrWhiteSpace(_path.Value) || _type.Type == null)
                return false;

            var asset = Resources.Load(_path.Value, _type.Type);
            var exists = asset != null;

            if (exists && _unloadAssetAfterCheck.Value && CanUnload(asset))
                Resources.UnloadAsset(asset);

            return exists;
        }

        private static bool CanUnload(Object asset)
            => asset is not (GameObject or Component or AssetBundle);

        protected override string TrueSummary => "{_path} ({_type}) exists";
        protected override string FalseSummary => "{_path} ({_type}) does not exist";
    }
}