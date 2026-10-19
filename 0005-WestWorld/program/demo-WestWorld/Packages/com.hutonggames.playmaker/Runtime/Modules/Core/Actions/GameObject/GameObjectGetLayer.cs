using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get a GameObject's Layer.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-layer.html")]
    public class GameObjectGetLayer : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [WriteOnly, Tooltip("Store the layer in an Integer variable")]
        public IntegerRef GetLayer;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            GetLayer.Value = GameObject.Value.layer;
        }
        
        public override string GetSummary() => "Get {GameObject} layer -> {GetLayer}";
    }
}