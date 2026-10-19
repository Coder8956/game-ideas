using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GetComponent")]
    [ActionDescription("Get the Rigidbody Component on a GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html")]
    public class GameObjectGetRigidbody : BaseAction
    {
        [Tooltip("The GameObject to check.")]
        public GameObjectVar GameObject;
        
        [WriteOnly, BaseType(typeof(Rigidbody))]
        [Tooltip("Store the result in a Rigidbody variable")]
        public ComponentRef StoreResult;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            StoreResult.Value = GameObject.Value.GetComponent<Rigidbody>();
        }
        
        public override string GetSummary() => "Get <b>Rigidbody</b> component on {GameObject} -> {StoreResult}";
    }
}
