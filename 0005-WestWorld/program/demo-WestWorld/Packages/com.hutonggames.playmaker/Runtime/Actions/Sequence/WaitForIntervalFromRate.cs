using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Sequence)]
    [ActionDescription("Wait before running more actions using an input rate per second. The wait interval is calculated as 1 / rate.",
        "Running actions keep running, but other actions won't start until this action has finished.")]
    public class WaitForIntervalFromRate : BaseWaitAction
    {
        [DefaultValue(1f)]
        [Tooltip("Rate per second. Wait interval is 1 / rate.")]
        public FloatVar Rate;

        [DefaultValue(false)]
        [Tooltip("Use unscaled realtime. When enabled, this wait is not affected by Time.timeScale.")]
        public BoolVar UseRealtime;

        private float _elapsedTime;
        private float _startTime;

        private float CurrentTime => UseRealtime.Value
            ? TimeHelper.RealtimeSinceStartup
            : InFixedUpdate ? Time.fixedTime : Time.time;

        private float Interval => Rate.Value > 0f ? 1f / Rate.Value : 0f;

        private float GetProgress()
        {
            var interval = Interval;
            if (interval > 0f)
            {
                return _elapsedTime / interval;
            }

            return 1f;
        }

        public override bool CanExecute() => CheckParameters(Rate, UseRealtime);

        public override void OnStart()
        {
            _elapsedTime = 0f;
            _startTime = CurrentTime;
        }

        public override void Execute()
        {
            var interval = Interval;
            if (interval <= 0f)
            {
                Progress = 1f;
                Finish();
                return;
            }

            _elapsedTime = Mathf.Max(0f, CurrentTime - _startTime);

            if (_elapsedTime > interval)
            {
                Progress = 1f;
                Finish();
            }
            else
            {
                Progress = GetProgress();
            }
        }

        public override string GetSummary() => "Wait for interval 1 / {Rate} seconds {UseRealtime:option}";
    }
}
