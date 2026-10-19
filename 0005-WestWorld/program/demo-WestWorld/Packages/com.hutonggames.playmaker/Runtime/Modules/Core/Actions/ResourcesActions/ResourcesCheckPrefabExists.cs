using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription(
        "Checks if a Prefab exists in a Resources folder by attempting to load it.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Resources.Load.html")]
    public sealed class ResourcesCheckPrefabExists : BaseTrueFalseAction
    {
        [Tooltip("Path to the prefab (relative to a Resources folder, without extension).")]
        [SerializeField]
        private StringVar _path;

        protected override bool Test()
        {
            if (string.IsNullOrWhiteSpace(_path.Value))
                return false;

            // Prefabs are always loaded as GameObject assets
            var prefab = Resources.Load<GameObject>(_path.Value);

            // IMPORTANT:
            // Do NOT call Resources.UnloadAsset on prefabs.
            // Unity explicitly disallows it, and unloading prefabs is not a valid workflow.
            return prefab != null;
        }

        protected override string TrueSummary => "Prefab {_path} exists";
        protected override string FalseSummary => "Prefab {_path} does not exist";
    }
}