using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get the name of a GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Object-name.html")]
    public class GameObjectGetName : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [Tooltip("Store the name in a String variable")]
        [WriteOnly, DefaultName("Name")]
        public StringRef StoreResult;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            StoreResult.Value = GameObject.Value.name;
        }
        
        public override string GetSummary() => "Get {GameObject} name -> {StoreResult}";
    }
}
