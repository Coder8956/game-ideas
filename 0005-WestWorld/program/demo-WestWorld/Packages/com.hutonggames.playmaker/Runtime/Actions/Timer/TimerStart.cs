using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Timer)]
    [ActionDescription("Start or restart a Timer.")]
    public sealed class TimerStart : BaseTimerAction
    {
        [Tooltip("Timer duration in seconds.")]
        public FloatVar Duration;

        [DefaultValue(false)]
        [Tooltip("Use unscaled realtime. When enabled, this timer is not affected by Time.timeScale.")]
        public BoolVar UseRealtime;

        public override bool CanExecute() => !Timer.IsNone && CheckParameters(Duration, UseRealtime);

        public override void Execute()
        {
            GetOrCreateTimer().Start(Duration.Value, UseRealtime.Value);
        }

        public override string GetSummary() => "Start {Timer} for {Duration} seconds {UseRealtime:option}";
    }
}
