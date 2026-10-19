using System;
using HutongGames.Reflection;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Loads the asset of the requested type stored at path in a Resources folder.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Resources.Load.html")]
    public class ResourcesLoad : BaseAction
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
        [Tooltip("Store the result in a variable")]
        private IVariableRef _storeResult;

        [Tooltip("Was the asset found")]
        [SerializeField, WriteOnly, OptionalField]
        private BoolRef _succeeded;

        public override bool CanExecute() => CheckParameters(_path, _type, _storeResult);

        public override void Execute()
        {
            var asset = Resources.Load(_path.Value, _type.Type);
            
            _storeResult.SetValue(asset);
            
            if (_succeeded.IsAssigned)
                _succeeded.Value = asset != null;
        }
    }
}