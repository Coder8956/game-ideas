using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformTransform")]
    [ActionDescription("Transform a vector from world space to local space.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.InverseTransformVector.html")]
    public class TransformInverseTransformVector : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [Tooltip("The vector to transform.")]
        public Vector3Var Vector;
        
        [WriteOnly, Tooltip("Transform the vector from world space to local space and store the result.")]
        public Vector3Ref InverseTransformVector;

        public override bool CanExecute() => CheckParameters(Transform, Vector, InverseTransformVector);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            InverseTransformVector.Value = transform.InverseTransformVector(Vector.Value);
        }
        
        public override string GetSummary() => "Transform {Vector} from world space to {Transform} local space -> {InverseTransformVector}";
    }
}
