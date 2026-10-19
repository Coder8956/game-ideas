using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Get a GameObject's Tag.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-tag.html")]
    public class GameObjectGetTag : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [WriteOnly, Tooltip("Store the Tag in a String variable")]
        public StringRef GetTag;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject, GetTag)) return;
            GetTag.Value = GameObject.Value.tag;
        }
        
        public override string GetSummary() => "Get {GameObject} tag -> {GetTag}";
    }
}
