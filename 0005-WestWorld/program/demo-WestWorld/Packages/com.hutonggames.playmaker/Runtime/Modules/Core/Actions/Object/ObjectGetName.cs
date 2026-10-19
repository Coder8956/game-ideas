using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Object)]
    [ActionDescription("Get the name of an Object.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object-name.html")]
    public class ObjectGetName : BaseAction
    {
        [Tooltip("The Object.")]
        [BaseType(typeof(Object))]
        public ObjectVar Object;
        
        [Tooltip("Store the name in a String variable")]
        [WriteOnly]
        public StringRef StoreResult;
        
        public override void Execute()
        {
            if (!RuntimeCheck(Object)) return;
            StoreResult.Value = Object.Value.name;
        }
        
        public override string GetSummary() => "Get {Object} name -> {StoreResult}";
    }
}
