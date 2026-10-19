using System;
using HutongGames.Reflection;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Resources)]
    [ActionDescription("Loads the asset of the requested type stored at path in a Resources folder.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Resources.Load.html")]
    public abstract class BaseResourcesLoad<T, TRef> : BaseAction where T : Object where TRef : IVariableRef
    {
        [Tooltip("Path to the target resource to load.")]
        [SerializeField]
        protected StringVar _path;
        
        [SerializeReference]
        [SerializeField, WriteOnly]
        [Tooltip("Store the result in a variable")]
        protected TRef _storeResult;

        [Tooltip("Was the asset found")]
        [SerializeField, WriteOnly, OptionalField]
        protected BoolRef _succeeded;

        public override bool CanExecute() => CheckParameters(_path, _storeResult);

        public override void Execute()
        {
            var asset = Resources.Load<T>(_path.Value);
            
            _storeResult.SetValue(asset);
            
            if (_succeeded.IsAssigned)
                _succeeded.Value = asset != null;
        }
        
        public override string GetSummary() => "Load {_path} -> {_storeResult}";
    }
}