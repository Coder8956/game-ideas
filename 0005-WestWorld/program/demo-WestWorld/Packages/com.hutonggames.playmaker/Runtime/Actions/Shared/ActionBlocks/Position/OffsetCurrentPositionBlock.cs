using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Defines a position using an offset from the Current Position.
    /// </summary>
    [Serializable]
    [DisplayOrder(2)]
    [Tooltip("Use the current position of the target object with an offset.")]
    public class OffsetCurrentPositionBlock : BasePositionBlock
    {
        [Tooltip("Offset from the current position.")]
        public Vector3Var OffsetPosition;
        
        [LocalSpace, HideLabel]
        [Tooltip("Coordinates for the Offset")]
        public Space InSpace;

        public override bool IsValid => Action.TargetTransform != null && OffsetPosition.HasValue();
        
        public override Vector3 GetWorldPosition() => InSpace == Space.Self 
                ? Action.TargetTransform.TransformPoint(OffsetPosition.Value)
                : Action.TargetTransform.position + OffsetPosition.Value;

        public override void SetWorldPosition(Vector3 position) =>
            OffsetPosition.Value = InSpace == Space.Self 
                ? Action.TargetTransform.InverseTransformPoint(position) 
                : position - Action.TargetTransform.position;
        
        public override string GetSummary() => "Offset: {OffsetPosition}";
    }
}