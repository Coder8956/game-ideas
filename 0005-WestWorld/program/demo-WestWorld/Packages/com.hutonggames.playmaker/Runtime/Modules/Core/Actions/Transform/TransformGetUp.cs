using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformDirection")]
    [ActionDescription("Get the up vector (green axis) of the transform in world space.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform-up.html")]
    public class TransformGetUp : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the up vector in world space.")]
        public Vector3Ref GetUp;

        public override bool CanExecute() => CheckParameters(Transform, GetUp);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetUp.Value = transform.up;
        }
        
        public override string GetSummary() => "Get {Transform} up -> {GetUp}";
    }
}