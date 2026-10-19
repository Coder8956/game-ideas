using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Transform)]
    [ActionDescription("Get the closest point on a transform axis to a world position.")]
    [HelpURL("actions/transform-actions/measurement-actions/")]
    public class TransformFindClosestPointOnAxis : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;

        [Tooltip("The world position to compare against the transform axis.")]
        public Vector3Var WorldPosition;

        [Tooltip("Which local transform axis to use.")]
        public RotationAxisVar Axis;

        [WriteOnly, Tooltip("Store the closest world point on the axis.")]
        public Vector3Ref ClosestPoint;

        public override bool CanExecute() => CheckParameters(Transform, WorldPosition, Axis, ClosestPoint);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;

            var axisDirection = Axis.Value switch
            {
                RotationAxis.X => transform.right,
                RotationAxis.Y => transform.up,
                RotationAxis.Z => transform.forward,
                _ => transform.forward
            };

            var origin = transform.position;
            var toPoint = WorldPosition.Value - origin;
            ClosestPoint.Value = origin + Vector3.Project(toPoint, axisDirection);
        }

        public override string GetSummary() =>
            "Get closest point on {Transform} {Axis} to {WorldPosition} -> {ClosestPoint}";
    }
}
