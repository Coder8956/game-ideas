using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameplayTargetingTransform)]
    [ConvertibleGroup("TransformGetDistance")]
    [ActionDescription("Get the distance of the transform to a world point.")]
    [HelpURL("actions/transform-actions/measurement-actions/")]
    public class TransformGetDistanceToPoint : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [Tooltip("A position in the world.")]
        public Vector3Var WorldPoint;
        
        [WriteOnly, Tooltip("Store the distance in a float variable.")]
        public FloatRef GetDistance;

        [Tooltip("The axis used to measure the distance.")]
        [SerializeField]
        private MoveAxisVar _axis;
        
        public override bool CanExecute() => CheckParameters(Transform, WorldPoint, GetDistance, _axis);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            GetDistance.Value = MoveAxisHelper.GetDistance(_axis.Value, transform.position, WorldPoint.Value);
        }
        
        public override string GetSummary() => "Get distance from {Transform} to {WorldPoint} -> {GetDistance} ({_axis})";
    }
}
