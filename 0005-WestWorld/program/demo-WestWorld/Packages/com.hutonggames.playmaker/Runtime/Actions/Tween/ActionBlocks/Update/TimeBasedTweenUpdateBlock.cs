using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Time Based Update")]
    [DisplayOrder(0)]
    [Tooltip("Update the tween based on time.")]
    public class TimeBasedTweenUpdateBlock : DurationBasedTweenUpdateBlock
    {
        [DefaultValue(1f)]
        [Tooltip("How many seconds the tween should take to complete.")]
        public FloatVar Duration;
        
        protected override float TweenDuration => Duration.Value;
        public override bool IsValid => Duration.Value >= 0;

        public override string GetSummary() => "in {Duration:seconds}";
    }
}