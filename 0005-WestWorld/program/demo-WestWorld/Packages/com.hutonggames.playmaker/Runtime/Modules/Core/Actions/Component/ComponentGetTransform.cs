using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Component)]
    [ActionDescription("Get the Transform attached to this GameObject.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Component-transform.html")]
    public class ComponentGetTransform : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Component to get the Transform from.")]
        public ComponentVar Component;
        
        [WriteOnly, Tooltip("Store the Transform in a Transform variable")]
        public TransformRef GetTransform;
        
        public override void Execute()
        {
            if (!RuntimeCheck(Component, GetTransform)) return;
            GetTransform.Value = Component.Value.transform;
        }
        
        public override string GetSummary() => "Get {Component} transform -> {GetTransform}";
    }
}
