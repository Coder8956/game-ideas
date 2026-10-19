using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [Tooltip("Use an offset from the current scale.")]
    public class OffsetScaleBlock : BaseScaleBlock
    {
        [Tooltip("Offset from the current scale.")]
        public Vector3Var OffsetScale;
        
        public override bool IsValid => Action.TargetTransform != null && OffsetScale.HasValue();
        
        public override Vector3 GetScale()
        {
            return Action.TargetTransform.localScale + OffsetScale.Value;
        }

        public override void SetScale(Vector3 scale)
        {
            OffsetScale.Value = scale - Action.TargetTransform.localScale;
        }
    }
}