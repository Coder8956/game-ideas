using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformDirection")]
    [ActionDescription("Get the forward vector (blue axis) of the transform in world space.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-forward.html")]
    public class TransformGetForward : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the forward vector in world space.")]
        public Vector3Ref GetForward;

        public override bool CanExecute() => CheckParameters(Transform, GetForward);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetForward.Value = transform.forward;
        }
        
        public override string GetSummary() => "Get {Transform} forward -> {GetForward}";
    }
}