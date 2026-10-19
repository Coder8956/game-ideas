using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    /// <summary>
    /// Manual update uses a float variable to directly set the progress
    /// (normalized time of the tween). This lets users create interesting
    /// relationships between measurements and tween progress.
    /// TODO: It might be interesting to add max speed of change or smoothing?
    /// </summary>
    [Serializable]
    [DisplayName("Manual Update")]
    [DisplayOrder(100)] // Always last
    [Tooltip("Update the tween manually.")]
    public class ManualTweenUpdateBlock : TweenUpdateBlock
    {
        [Tooltip("Set the progress of the tween using a float variable. " +
                 "\nValue should be between 0 and 1.")]
        public FloatRef TweenTime;

        public override bool IsValid => TweenTime.HasValue();

        public override float GetProgress() => TweenTime.Value;

        public override string GetSummary() => "Manual Update: {TweenTime}";
    }
}