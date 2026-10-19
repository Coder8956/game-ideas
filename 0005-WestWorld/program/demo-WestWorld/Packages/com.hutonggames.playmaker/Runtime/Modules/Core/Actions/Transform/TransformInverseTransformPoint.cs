using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformTransform")]
    [ActionDescription("Transform a point from world space to local space.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.InverseTransformPoint.html")]
    public class TransformInverseTransformPoint : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [Tooltip("The point to transform.")]
        public Vector3Var Point;
        
        [WriteOnly, Tooltip("Transform the point from world space to local space and store the result.")]
        public Vector3Ref InverseTransformPoint;

        public override bool CanExecute() => CheckParameters(Transform, Point, InverseTransformPoint);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            InverseTransformPoint.Value = transform.InverseTransformPoint(Point.Value);
        }
        
        public override string GetSummary() => "Transform {Point} from world space to {Transform} local space -> {InverseTransformPoint}";
    }
}
