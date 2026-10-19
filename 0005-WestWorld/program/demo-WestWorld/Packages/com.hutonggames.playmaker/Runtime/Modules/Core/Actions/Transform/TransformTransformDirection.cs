using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformTransform")]
    [ActionDescription("Transform a direction from local space to world space.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.TransformDirection.html")]
    public class TransformTransformDirection : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [Tooltip("The direction to transform.")]
        public Vector3Var Direction;
        
        [WriteOnly, Tooltip("Store the transformed direction.")]
        public Vector3Ref TransformDirection;

        public override bool CanExecute() => CheckParameters(Transform, Direction, TransformDirection);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            TransformDirection.Value = transform.TransformDirection(Direction.Value);
        }
        
        public override string GetSummary() => "Transform {Direction} from {Transform} local space to world space -> {TransformDirection}";
    }
}
