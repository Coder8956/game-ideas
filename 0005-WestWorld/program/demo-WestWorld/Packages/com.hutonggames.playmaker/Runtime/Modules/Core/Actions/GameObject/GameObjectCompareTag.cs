using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.GameObject)]
    [ConvertibleGroup("GameObjectActive")]
    [ActionDescription("Checks if a GameObject is tagged with a tag.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/GameObject.CompareTag.html")]
    public class GameObjectCompareTag : BaseTrueFalseAction
    {
        [Tooltip("The GameObject to check.")]
        public GameObjectVar GameObject;
        
        [TagValue, CanBeNullOrEmpty]
        [Tooltip("The tag to check for.")]
        public StringVar Tag;
        
        protected override bool Test() => GameObject.Value != null && !string.IsNullOrEmpty(Tag.Value) && GameObject.Value.CompareTag(Tag.Value);
        protected override string TrueSummary => "{GameObject} has tag {Tag}";
        protected override string FalseSummary => "{GameObject} does not have {Tag}";
    }
}