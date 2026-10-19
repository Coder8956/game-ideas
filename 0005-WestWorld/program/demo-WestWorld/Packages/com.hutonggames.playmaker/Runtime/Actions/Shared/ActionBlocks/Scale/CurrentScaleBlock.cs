using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [Tooltip("Use the current scale of the target object.")]
    public class CurrentScaleBlock : BaseScaleBlock
    {
        public override bool IsValid => Action.TargetTransform != null;
        
        public override Vector3 GetScale()
        {
            return Action.TargetTransform.localScale;
        }

        public override void SetScale(Vector3 scale)
        {
            // fixed
        }
        
        public override string GetSummary()
        {
            return "Current Scale";
        }
    }
}