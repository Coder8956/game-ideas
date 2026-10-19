using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Component)]
    [ActionDescription("Get the tag of this GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Component-tag.html")]
    public class ComponentGetTag : BaseAction
    {
        [Tooltip("The Component.")]
        public ComponentVar Component;
        
        [WriteOnly, Tooltip("Store the Tag in a String variable")]
        public StringRef GetTag;
        
        public override void Execute()
        {
            if (!RuntimeCheck(Component, GetTag)) return;
            GetTag.Value = Component.Value.tag;
        }
        
        public override string GetSummary() => "Get {Component} tag -> {GetTag}";
    }
}