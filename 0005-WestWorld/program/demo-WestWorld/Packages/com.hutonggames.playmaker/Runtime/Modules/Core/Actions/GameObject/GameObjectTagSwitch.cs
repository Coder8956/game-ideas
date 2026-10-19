using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.LogicFlow)]
    [ActionDescription("Send events based on a GameObject's Tag.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject-tag.html")]
    public class GameObjectTagSwitch : BaseAction
    {
        [Tooltip("The GameObject.")]
        public GameObjectVar GameObject;

        [Tooltip("Send events based on the GameObject's Tag.")]
        public StringEventSwitch TagSwitch;
        
        public override void Execute()
        {
            if (!RuntimeCheck(GameObject)) return;

            var tag = GameObject.Value.tag;
            var evt = TagSwitch.Evaluate(tag);
            if (evt != null)
            {
                SendEvent(evt);
            }
        }
        
        public override string GetSummary() => "Switch on {GameObject} tag: " + TagSwitch?.GetSummary();
    }
}
