using System;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Timer)]
    [ActionDescription("Reset a Timer without removing it from the variable.")]
    public sealed class TimerReset : BaseTimerAction
    {
        public override void Execute()
        {
            GetTimer()?.Reset();
        }

        public override string GetSummary() => "Reset {Timer}";
    }
}
