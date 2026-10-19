using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get if a GameObject is static.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-isStatic.html")]
    public class GameObjectGetIsStatic : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;

        [WriteOnly]
        [Tooltip("Store the result in a Bool variable")]
        public BoolRef StoreResult;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            StoreResult.Value = GameObject.Value.isStatic;
        }
        
        public override string GetSummary() => "Get {GameObject} is static -> {StoreResult}";
    }
}
