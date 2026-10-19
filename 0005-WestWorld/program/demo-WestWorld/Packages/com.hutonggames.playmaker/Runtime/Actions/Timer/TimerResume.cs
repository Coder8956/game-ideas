using System;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Timer)]
    [ActionDescription("Resume a paused Timer.")]
    public sealed class TimerResume : BaseTimerAction
    {
        public override void Execute()
        {
            GetTimer()?.Resume();
        }

        public override string GetSummary() => "Resume {Timer}";
    }
}
