using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformTransform")]
    [ActionDescription("Transform a vector from local space to world space.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.TransformVector.html")]
    public class TransformTransformVector : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [Tooltip("The vector to transform.")]
        public Vector3Var Vector;
        
        [WriteOnly, Tooltip("Store the transformed vector.")]
        public Vector3Ref TransformVector;

        public override bool CanExecute() => CheckParameters(Transform, Vector, TransformVector);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            TransformVector.Value = transform.TransformVector(Vector.Value);
        }
        
        public override string GetSummary() => "Transform {Vector} from {Transform} local space to world space -> {TransformVector}";
    }
}
