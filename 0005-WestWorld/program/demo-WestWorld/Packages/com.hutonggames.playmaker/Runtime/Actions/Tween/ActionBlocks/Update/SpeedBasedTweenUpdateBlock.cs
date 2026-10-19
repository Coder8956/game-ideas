using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayName("Speed Based Update")]
    [DisplayOrder(1)]
    [Tooltip("Update the tween based on desired speed.")]
    public class SpeedBasedTweenUpdateBlock : DurationBasedTweenUpdateBlock
    {
        [Tooltip("The desired speed for the Tween (units per second)." +
                 "\nLower speed = longer duration.")]
        [DefaultValue(1f)]
        public FloatVar Speed;

        protected override float TweenDuration => TweenAction.Distance / Speed.Value;

        /// <summary>
        /// NOTE: We don't check TweenAction.Distance >=0 because it's not known before OnStart.
        /// </summary>
        public override bool IsValid => Speed.HasValue(); 
        
        public override string GetSummary() => "Speed: {Speed}";
    }
}