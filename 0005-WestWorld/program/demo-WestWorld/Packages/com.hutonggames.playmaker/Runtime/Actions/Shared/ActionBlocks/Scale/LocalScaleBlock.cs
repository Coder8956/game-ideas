using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayOrder(0)]
    [Tooltip("Set the local scale of the target object.")]
    public class LocalScaleBlock : BaseScaleBlock
    {
        [DefaultValue("Vector3.one")]
        [Tooltip("Set the local scale.")]
        public Vector3Var LocalScale;

        public override bool IsValid => LocalScale.HasValue();
        
        public override Vector3 GetScale() => LocalScale.Value;

        public override void SetScale(Vector3 scale) => LocalScale.Value = scale;

        public override string GetSummary() => "{LocalScale}";
    }
}