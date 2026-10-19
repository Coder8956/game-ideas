/* Duplicate of GameObjectGetActiveInHierarchy
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GameObjectActive")]
    [ActionDescription("Get if a GameObject is active in the hierarchy.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-activeInHierarchy.html")]
    public class GameObjectGetIsActiveInHierarchy : BaseAction
    {
        [Tooltip("The GameObject to check.")]
        public GameObjectVar GameObject;

        [WriteOnly]
        [Tooltip("Store the result in a Bool variable")]
        public BoolRef StoreResult;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            StoreResult.Value = GameObject.Value.activeInHierarchy;
        }
        
        public override string GetSummary() => "Get {GameObject} is active in hierarchy -> {StoreResult}";
    }
}
*/