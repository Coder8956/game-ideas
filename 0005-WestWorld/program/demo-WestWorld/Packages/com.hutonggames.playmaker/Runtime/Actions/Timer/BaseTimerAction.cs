using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Time)]
    public abstract class BaseTimerAction : BaseAction
    {
        [Tooltip("The Timer variable to use.")]
        public TimerRef Timer;

        public override bool CanExecute() => !Timer.IsNone;

        protected Timer GetTimer() => Timer.Value;

        protected Timer GetOrCreateTimer()
        {
            var timer = Timer.Value;
            if (timer != null) return timer;

            timer = new Timer();
            Timer.Value = timer;
            return timer;
        }
    }
}
