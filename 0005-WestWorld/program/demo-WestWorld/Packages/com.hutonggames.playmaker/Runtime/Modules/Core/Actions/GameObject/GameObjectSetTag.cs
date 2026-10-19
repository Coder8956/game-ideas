using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ActionDescription("Set a GameObject's Tag.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-tag.html")]
    public class GameObjectSetTag : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;
        
        [TagValue, CanBeNullOrEmpty]
        [Tooltip("Set the Tag of the GameObject.")]
        public StringVar SetTag;
        
        public override bool CanExecute() => CheckParameters(GameObject);
        
        public override void Execute() => GameObject.Value.tag = SetTag.Value;

        public override string GetSummary() => "Set {GameObject} tag to {SetTag}";
    }
}
