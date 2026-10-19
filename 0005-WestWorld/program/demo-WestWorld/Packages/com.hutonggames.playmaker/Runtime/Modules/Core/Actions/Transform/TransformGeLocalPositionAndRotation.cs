using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformGetPosition")]
    [ActionDescription("Gets the position and rotation of the Transform in local space (relative to its parent transform).")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.GetLocalPositionAndRotation.html")]
    public class TransformGetLocalPositionAndRotation : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the world position.")]
        public Vector3Ref GetLocalPosition;

        [WriteOnly, Tooltip("Store the world rotation in a Quaternion variable.")]
        public QuaternionRef GetLocalRotation;
        
        public override bool CanExecute() => CheckParameters(Transform, GetLocalPosition, GetLocalRotation);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            transform.GetLocalPositionAndRotation(out var position, out var rotation);
            GetLocalPosition.Value = position;
            GetLocalRotation.Value = rotation;
        }
        
        public override string GetSummary() => "Get {Transform} local position -> {GetLocalPosition} and local rotation -> {GetLocalRotation}";
    }
}