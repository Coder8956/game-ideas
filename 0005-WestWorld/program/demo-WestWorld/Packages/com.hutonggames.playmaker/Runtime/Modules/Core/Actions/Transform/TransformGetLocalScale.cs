using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformScale")]
    [ActionDescription("Get the scale of the transform relative to the transform's parent.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localScale.html")]
    public class TransformGetLocalScale : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the local scale in a Vector3 variable.")]
        public Vector3Ref GetLocalScale;

        public override bool CanExecute() => CheckParameters(Transform, GetLocalScale);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetLocalScale.Value = transform.localScale;
        }
        
        public override string GetSummary() => "Get {Transform} local scale -> {GetLocalScale}";
    }
}