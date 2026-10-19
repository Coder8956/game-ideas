using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformDirection")]
    [ActionDescription("Get the right vector (red axis) of the transform in world space.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-right.html")]
    public class TransformGetRight : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the right vector in world space.")]
        public Vector3Ref GetRight;

        public override bool CanExecute() => CheckParameters(Transform, GetRight);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetRight.Value = transform.right;
        }
        
        public override string GetSummary() => "Get {Transform} right -> {GetRight}";
    }
}