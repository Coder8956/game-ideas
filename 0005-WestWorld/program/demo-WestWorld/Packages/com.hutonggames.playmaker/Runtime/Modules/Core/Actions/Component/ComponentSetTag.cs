using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Component)]
    [ActionDescription("Set the tag of this GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Component-tag.html")]
    public class ComponentSetTag : BaseAction
    {
        [Tooltip("The Component.")]
        public ComponentVar Component;
        
        [TagValue, CanBeNullOrEmpty]
        [Tooltip("Set the Tag of the GameObject.")]
        public StringVar SetTag;
        
        public override bool CanExecute() => CheckParameters(Component);
        
        public override void Execute() => Component.Value.tag = SetTag.Value;

        public override string GetSummary() => "Set {Component} tag to {SetTag}";
    }
}
