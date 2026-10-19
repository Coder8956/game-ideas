using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformGetPosition")]
    [ActionDescription("Get the position of the transform relative to the parent transform.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-localPosition.html")]
    public class TransformGetLocalPosition2D : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the local position in a Vector2 variable.")]
        public Vector2Ref GetLocalPosition;

        public override bool CanExecute() => CheckParameters(Transform, GetLocalPosition);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetLocalPosition.Value = transform.localPosition;
        }
        
        public override string GetSummary() => "Get {Transform} local position -> {GetLocalPosition}";
    }
}