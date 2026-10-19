using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ConvertibleGroup("TransformTransform")]
    [ActionDescription("Transform a point from local space to world space.")]
    [HelpURL("https://docs.unity3d.com/ScriptReference/Transform.TransformPoint.html")]
    public class TransformTransformPoint : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [Tooltip("The local point to transform.")]
        public Vector3Var LocalPoint;
        
        [WriteOnly, Tooltip("Store the transformed point.")]
        public Vector3Ref WorldSpacePoint;

        public override bool CanExecute() => CheckParameters(Transform, LocalPoint, WorldSpacePoint);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            WorldSpacePoint.Value = transform.TransformPoint(LocalPoint.Value);
        }
        
        public override string GetSummary() => "Transform {LocalPoint} from {Transform} to world space -> {WorldSpacePoint}";
    }
}