using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.GameplayTargetingTransform)]
    [ConvertibleGroup("TransformGetDistance")]
    [ActionDescription("Get the distance of the transform to a target.")]
    [HelpURL("actions/transform-actions/measurement-actions/")]
    public class TransformGetDistanceToTarget : BaseAction
    {
        [OwnerDefaultValue]
        [Tooltip("The Transform.")]
        public TransformVar Transform;
        
        [Tooltip("The Target Transform.")]
        public TransformVar Target;
        
        [WriteOnly, Tooltip("Store the distance in a float variable.")]
        public FloatRef GetDistance;
        [Tooltip("The axis used to measure the distance.")]
        [SerializeField]
        private MoveAxisVar _axis;
        
        public override bool CanStart() => CheckParameters(Transform, Target, GetDistance);

        public override bool CanExecute() => CheckParameters(GetDistance);

        public override void Execute()
        {
            var transform = Transform.Value;
            if (transform == null) return;
            
            var target = Target.Value;
            if (target == null) return;
            
            GetDistance.Value = MoveAxisHelper.GetDistance(_axis.Value, transform.position, target.position);
        }
        
        public override string GetSummary() => "Get distance from {Transform} to {Target} -> {GetDistance} ({_axis})";
    }
}
