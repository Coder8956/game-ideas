using System;
using HutongGames.Reflection;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Loads all assets in a folder or file at path in a Resources folder.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Resources.LoadAll.html")]
    public class ResourcesLoadAll : BaseAction
    {
        [Tooltip("Path to the target resource to load.")]
        [SerializeField]
        private StringVar _path;
        
        [BaseType(typeof(UnityEngine.Object))]
        [Tooltip("The type of asset to load.")]
        [SerializeField]
        private TypeReference _type;
        
        [SerializeReference]
        [SerializeField, WriteOnly, MatchType(nameof(_type))]
        [Tooltip("Store the result in a list variable.")]
        private IListVariableRef _storeResult;

        public override bool CanExecute() => CheckParameters(_path, _type, _storeResult);

        public override void Execute()
        {
            var assets = Resources.LoadAll(_path.Value, _type.Type);
            
            _storeResult.SetValue(assets);
        }
    }
}