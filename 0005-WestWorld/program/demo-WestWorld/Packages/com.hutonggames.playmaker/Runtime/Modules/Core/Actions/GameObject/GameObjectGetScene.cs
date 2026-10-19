using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get the scene that a GameObject is part of.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-scene.html")]
    public class GameObjectGetScene : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [WriteOnly, Tooltip("Store the scene in a Scene variable")]
        public SceneRef GetScene;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            GetScene.Value = GameObject.Value.scene;
        }
        
        public override string GetSummary() => "Get {GameObject} scene -> {GetScene}";
    }
}
