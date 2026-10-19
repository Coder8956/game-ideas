using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription(
        "Unloads an asset from memory. " +
        "This can only be used on individual asset objects loaded from disk " +
        "(e.g. Texture2D, AudioClip, Material). " +
        "It cannot be used on GameObjects, Components, or AssetBundles."
    )]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Resources.UnloadAsset.html")]
    public sealed class ResourcesUnloadAsset : BaseAction
    {
        [BaseType(typeof(Object))]
        [SerializeReference]
        [Tooltip(
            "The asset to unload. This must be an individual asset (e.g. Texture2D, AudioClip, Material). " +
            "Do not use this on GameObjects or Components. Use Destroy instead."
        )]
        private IVariableRef _asset;

        [Tooltip("Clear the variable after unloading (recommended).")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _clearVariable;

        [Tooltip("True if the asset was unloaded.")]
        [SerializeField, WriteOnly, OptionalField]
        private BoolRef _succeeded;

        public override bool CanExecute() => CheckParameters(_asset);

        public override void Execute()
        {
            var asset = _asset.GetValue() as Object;

            if (asset == null)
            {
                SetSucceeded(true);
                return;
            }

            // Explicitly block unsupported types to avoid Unity exceptions
            if (asset is GameObject || asset is Component || asset is AssetBundle)
            {
                LogWarning(
                    "ResourcesUnloadAsset cannot be used on GameObjects, Components, or AssetBundles. " +
                    "Use Destroy for instances and ResourcesUnloadUnusedAssets for cleanup."
                );

                SetSucceeded(false);
                return;
            }

            Resources.UnloadAsset(asset);

            if (_clearVariable.Value)
                _asset.SetValue(null);

            SetSucceeded(true);
        }

        private void SetSucceeded(bool value)
        {
            if (_succeeded.IsAssigned)
                _succeeded.Value = value;
        }

        public override string GetSummary() => "Unload {_asset}";
    }
}
