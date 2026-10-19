using System;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Timer)]
    [ActionDescription("Pause a running Timer.")]
    public sealed class TimerPause : BaseTimerAction
    {
        public override void Execute()
        {
            GetTimer()?.Pause();
        }

        public override string GetSummary() => "Pause {Timer}";
    }
}
