using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("GetChild")]
    [ActionDescription("Find a child by name in a Transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.Find.html")]
    public class TransformFindChild : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;

        [Tooltip("The name of the child to find.")]
        public StringVar ChildName;
        
        [ConvertibleName("Child")]
        [WriteOnly, Tooltip("Store the child (or null if not found).")]
        public TransformRef FindChild;

        public override bool CanExecute() => CheckParameters(Transform, ChildName, FindChild);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            FindChild.Value = transform.Find(ChildName.Value);
        }
        
        public override string GetSummary() => "Find {Transform} child {ChildName} -> {FindChild}";
    }
}