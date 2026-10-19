using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformGetPosition")]
    [ActionDescription("Get the position and rotation of the Transform component in world space.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.GetPositionAndRotation.html")]
    public class TransformGetPositionAndRotation : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [WriteOnly, Tooltip("Store the world position.")]
        public Vector3Ref GetPosition;

        [WriteOnly, Tooltip("Store the world rotation in a Quaternion variable.")]
        public QuaternionRef GetRotation;
        
        public override bool CanExecute() => CheckParameters(Transform, GetPosition, GetRotation);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            transform.GetPositionAndRotation(out var position, out var rotation);
            GetPosition.Value = position;
            GetRotation.Value = rotation;
        }
        
        public override string GetSummary() => "Get {Transform} position -> {GetPosition} and rotation -> {GetRotation}";
    }
}