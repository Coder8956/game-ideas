using System;
using System.Collections.Generic;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("GetChild")]
    [ActionDescription("Get all children of a Transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.html")]
    public class TransformGetChildren : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the children.")]
        public TransformListRef GetChildren;

        public override bool CanExecute() => CheckParameters(Transform, GetChildren);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            
            var children = new List<Transform>();
            foreach (Transform child in transform)
            {
                children.Add(child);
            }
            GetChildren.Value = children;
        }
        
        public override string GetSummary() => "Get {Transform} children -> {GetChildren}";
    }
}
