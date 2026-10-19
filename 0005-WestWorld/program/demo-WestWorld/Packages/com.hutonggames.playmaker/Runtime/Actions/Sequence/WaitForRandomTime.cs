using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Sequence)]
    [ActionDescription("Wait for a random amount of time before running more actions.")]
    public class WaitForRandomTime : BaseWaitAction
    {
        [DefaultValue(1f)]
        [Tooltip("Minimum amount of time to wait in seconds.")]
        public FloatVar MinTime;
        
        [DefaultValue(5f)]
        [Tooltip("Maximum amount of time to wait in seconds.")]
        public FloatVar MaxTime;

        [DefaultValue(false)]
        [Tooltip("Use unscaled realtime. When enabled, this wait is not affected by Time.timeScale.")]
        public BoolVar UseRealtime;

        private float _finishedTime;
        private float _elapsedTime;
        private float _startTime;

        private float CurrentTime => UseRealtime.Value
            ? TimeHelper.RealtimeSinceStartup
            : InFixedUpdate ? Time.fixedTime : Time.time;

        private float GetProgress()
        {
            if (_finishedTime > 0)
            {
                return _elapsedTime / _finishedTime;
            }
            return 1;
        }

        public override bool CanExecute() => CheckParameters(MinTime, MaxTime, UseRealtime);

        public override void OnStart()
        {
            _finishedTime = Random.Range(MinTime.Value, MaxTime.Value);
            _elapsedTime = 0;
            _startTime = CurrentTime;
        }

        public override void Execute()
        {
            _elapsedTime = Mathf.Max(0f, CurrentTime - _startTime);

            if (_elapsedTime > _finishedTime)
            {
                Progress = 1;
                Finish();
            }
            else
            {
                Progress = GetProgress();
            }
        }
        
        public override string GetSummary() => "Wait for random time between {MinTime:seconds} and {MaxTime:seconds} {UseRealtime:option}";
    }
}

