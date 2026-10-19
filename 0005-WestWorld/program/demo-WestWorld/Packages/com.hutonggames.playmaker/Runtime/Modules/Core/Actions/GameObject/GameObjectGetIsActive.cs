/* Duplicate of GameObjectGetActiveSelf
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GameObjectActive")]
    [ActionDescription("Get if a GameObject is active.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-activeSelf.html")]
    public class GameObjectGetIsActive : BaseAction
    {
        [Tooltip("The GameObject to check.")]
        public GameObjectVar GameObject;

        [WriteOnly]
        [Tooltip("Store the result in a Bool variable")]
        public BoolRef StoreResult;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            StoreResult.Value = GameObject.Value.activeSelf;
        }
        
        public override string GetSummary() => "Get {GameObject} is active and store in {StoreResult}";
    }
}
*/