using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Object)]
    [ActionDescription("Do not destroy the target Object when loading a new Scene.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object.DontDestroyOnLoad.html")]
    public class ObjectDontDestroyOnLoad : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Object to preserve.")]
        [BaseType(typeof(Object))]
        public ObjectVar Object;
        
        public override void Execute()
        {
            if (!RuntimeCheck(Object)) return;
            UnityEngine.Object.DontDestroyOnLoad(Object.Value);
        }
        
        public override string GetSummary() => "{Object} DontDestroyOnLoad";
    }
}