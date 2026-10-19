using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [PublicAPI]
    [ActionCategory(Category.Timer)]
    [ConvertibleGroup("CheckTimerDone")]
    [ActionDescription("Check whether a Timer has completed.")]
    public sealed class TimerCheckDone : BaseTrueFalseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.UpdateEveryFrame;

        [Tooltip("The Timer variable to check.")]
        public TimerRef Timer;

        public override bool CanExecute() => !Timer.IsNone;

        protected override string TrueSummary => "{Timer} is done";
        protected override string FalseSummary => "{Timer} is not done";

        protected override bool Test()
        {
            var timer = Timer.Value;
            Progress = timer?.Progress ?? 0f;
            return timer is { IsDone: true };
        }
    }
}
