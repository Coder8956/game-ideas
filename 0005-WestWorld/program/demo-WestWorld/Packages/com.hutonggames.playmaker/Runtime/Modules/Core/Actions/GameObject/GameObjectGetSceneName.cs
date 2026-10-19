using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get the name of the scene that a GameObject is part of.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-scene.html")]
    public class GameObjectGetSceneName : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [WriteOnly, Tooltip("Store the scene name in a String variable")]
        public StringRef GetSceneName;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;
            GetSceneName.Value = GameObject.Value.scene.name;
        }
        
        public override string GetSummary() => "Get {GameObject} scene name -> {GetSceneName}";
    }
}
