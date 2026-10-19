using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Sequence)]
    [ActionDescription("Wait before running more actions. " +
                       "Running actions keep running, but other actions won't start until this action has finished.", 
        "Use before other actions to delay starting those actions. " +
        "E.g., Wait 1 second then Play Sound.\n\n" +
        "Use at the end of a block of actions to finish that block of actions after a set time. " +
        "E.g., Rotate to spin a GameObject then Wait to stop spinning after 1 second.")]
    public class WaitForSeconds : BaseWaitAction
    {
        [DefaultValue(1f)]
        [Tooltip("Time to wait in seconds.")]
        public FloatVar Seconds;

        [DefaultValue(false)]
        [Tooltip("Use unscaled realtime. When enabled, this wait is not affected by Time.timeScale.")]
        public BoolVar UseRealtime;

        private float _elapsedTime;
        private float _startTime;

        private float CurrentTime => UseRealtime.Value
            ? TimeHelper.RealtimeSinceStartup
            : InFixedUpdate ? Time.fixedTime : Time.time;

        private float GetProgress()
        {
            if (Seconds.Value > 0)
            {
                return _elapsedTime / Seconds.Value;
            }
            return 1;
        }

        public override bool CanExecute() => CheckParameters(Seconds, UseRealtime);

        public override void OnStart()
        {
            _elapsedTime = 0;
            _startTime = CurrentTime;
        }

        public override void Execute()
        {
            _elapsedTime = Mathf.Max(0f, CurrentTime - _startTime);

            if (_elapsedTime > Seconds.Value)
            {
                Progress = 1;
                Finish();
            }
            else
            {
                Progress = GetProgress();
            }
        }
        
        public override string GetSummary() => "Wait for {Seconds} seconds {UseRealtime:option}";
    }
}
