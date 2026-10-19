using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Get the rotation of the Action's current target.
    /// Note: The parent action has to set the Target.
    /// </summary>
    [Serializable]
    [DisplayOrder(1)]
    public class CurrentRotationBlock : BaseRotationBlock
    {
        public override bool IsValid => Action.TargetTransform != null;
        
        public override Quaternion GetRotation() => Action.TargetTransform.rotation;

        public override void SetRotation(Quaternion rotation)
        {
            // Nothing to do.
            // We could rotate the target object...? 
        }
        
        public override string GetSummary() => "Current Rotation";
    }
}