using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformTransform")]
    [ActionDescription("Transforms a direction from world space to local space. The opposite of Transform.TransformDirection.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.InverseTransformDirection.html")]
    public class TransformInverseTransformDirection : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [Tooltip("The direction to transform.")]
        public Vector3Var Direction;
        
        [WriteOnly, Tooltip("Store the transformed direction.")]
        public Vector3Ref InverseTransformDirection;

        public override bool CanExecute() => CheckParameters(Transform, Direction, InverseTransformDirection);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            InverseTransformDirection.Value = transform.InverseTransformDirection(Direction.Value);
        }
        
        public override string GetSummary() => "Transform {Direction} from world space to {Transform} local space -> {InverseTransformDirection}";
    }
}
