using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Component)]
    [ActionDescription("The game object this component is attached to. A component is always attached to a game object.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Component-gameObject.html")]
    public class ComponentGetGameObject : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Component.")]
        public ComponentVar Component;
        
        [WriteOnly, Tooltip("Store the GameObject in a GameObject variable")]
        public GameObjectRef GetGameObject;
        
        public override void Execute()
        {
            if (!RuntimeCheck(Component, GetGameObject)) return;
            GetGameObject.Value = Component.Value.gameObject;
        }
        
        public override string GetSummary() => "Get {Component} GameObject -> {GetGameObject}";
    }
}