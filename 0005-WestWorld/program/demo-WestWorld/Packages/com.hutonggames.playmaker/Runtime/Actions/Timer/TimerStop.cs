using System;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Timer)]
    [ActionDescription("Stop a Timer and clear its started state.")]
    public sealed class TimerStop : BaseTimerAction
    {
        public override void Execute()
        {
            GetTimer()?.Stop();
        }

        public override string GetSummary() => "Stop {Timer}";
    }
}
