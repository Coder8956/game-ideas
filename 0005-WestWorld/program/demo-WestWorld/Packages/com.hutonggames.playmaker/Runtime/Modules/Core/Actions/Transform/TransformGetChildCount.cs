using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("GetChild")]
    [ActionDescription("Get the number of children the parent Transform has.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-childCount.html")]
    public class TransformGetChildCount : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The parent Transform.")]
        public TransformVar ParentTransform;

        [WriteOnly]
        [Tooltip("Store the child count in a variable.")]
        public IntegerRef GetChildCount;

        public override bool CanExecute() => CheckParameters(ParentTransform, GetChildCount);

        public override void Execute()
        {
            var transform = ParentTransform.Value;
            if (transform == null) return;
            GetChildCount.Value = transform.childCount;
        }
        
        public override string GetSummary() => "Get {ParentTransform} child count -> {GetChildCount}";
    }
}