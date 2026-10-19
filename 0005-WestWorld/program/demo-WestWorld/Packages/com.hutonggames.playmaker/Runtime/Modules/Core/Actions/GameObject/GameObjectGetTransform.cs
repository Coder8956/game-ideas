using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get a GameObject's Transform. Use the Transform to position, rotate, and scale the GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-transform.html")]
    public class GameObjectGetTransform : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [WriteOnly, Tooltip("Store the Transform in a Transform variable")]
        public TransformRef GetTransform;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject, GetTransform)) return;
            GetTransform.Value = GameObject.Value.transform;
        }
        
        public override string GetSummary() => "Get {GameObject} transform -> {GetTransform}";
    }
}
