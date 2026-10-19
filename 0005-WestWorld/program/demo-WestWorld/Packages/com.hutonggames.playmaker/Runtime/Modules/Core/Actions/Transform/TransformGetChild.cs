using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("GetChild")]
    [ActionDescription("Get a child of a Transform by index.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.GetChild.html")]
    public class TransformGetChild : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;

        [Tooltip("The index of the child.")]
        public IntegerVar ChildIndex;
        
        [ConvertibleName("Child")]
        [WriteOnly, Tooltip("Store the child (or null if not found).")]
        public TransformRef GetChild;

        public override bool CanExecute() => CheckParameters(Transform, ChildIndex, GetChild);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            
            var index = ChildIndex.Value;
            GetChild.Value = index >= 0 && index < transform.childCount 
                ? transform.GetChild(ChildIndex.Value) 
                : null;
        }
        
        public override string GetSummary() => "Get {Transform} child {ChildIndex} -> {GetChild}";
    }
}