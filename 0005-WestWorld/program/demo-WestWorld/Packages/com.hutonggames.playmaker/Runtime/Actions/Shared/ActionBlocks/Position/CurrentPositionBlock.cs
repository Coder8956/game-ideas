using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Get the position of the Action's current target.
    /// Note: The parent action has to set the Target.
    /// </summary>
    [Serializable]
    [DisplayOrder(1)]
    [Tooltip("Use the current position of the target object.")]
    public class CurrentPositionBlock : BasePositionBlock
    {
        public override bool IsValid => Action.TargetTransform != null;
        
        public override Vector3 GetWorldPosition() => Action.TargetTransform.position;

        public override void SetWorldPosition(Vector3 position)
        {
            // Nothing to do.
            // Maybe translate the target object...? 
        }
        
        public override string GetSummary() => "Current Position";
    }
}