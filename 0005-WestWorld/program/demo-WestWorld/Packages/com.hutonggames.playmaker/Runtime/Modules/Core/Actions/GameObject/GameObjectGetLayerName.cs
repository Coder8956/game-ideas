using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get the name of a GameObject's Layer.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-layer.html")]
    public class GameObjectGetLayerName : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [WriteOnly, Tooltip("Store the layer name in a String variable")]
        public StringRef GetLayerName;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            GetLayerName.Value = LayerMask.LayerToName(GameObject.Value.layer);
        }
        
        public override string GetSummary() => "Get {GameObject} layer name -> {GetLayerName}";
    }
}
