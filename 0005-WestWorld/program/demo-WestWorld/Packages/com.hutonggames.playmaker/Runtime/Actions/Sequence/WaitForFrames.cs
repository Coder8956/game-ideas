using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Sequence)]
    [ActionDescription("Wait for a specified number of frames. Useful in loops that might otherwise loop infinitely.")]
    public class WaitForFrames : BaseWaitAction
    {
        [DefaultValue(1)]
        [Tooltip("Number of frames to wait. A value of 1 waits until the next frame.")]
        public IntegerVar Frames;

        [NonSerialized] private int _frameCount;

        private float GetProgress()
        {
            if (Frames.Value > 0)
            {
                return (float)_frameCount / Frames.Value;
            }

            return 1f;
        }

        public override bool CanExecute() => CheckParameters(Frames);

        public override void OnStart()
        {
            _frameCount = 0;
        }

        public override void Execute()
        {
            if (Frames.Value <= 0)
            {
                Progress = 1f;
                Finish();
                return;
            }

            if (_frameCount >= Frames.Value && CurrentUpdateMode == UpdateMode.Update)
            {
                Progress = 1f;
                Finish();
                return;
            }

            _frameCount = Mathf.Min(_frameCount + 1, Frames.Value);
            Progress = GetProgress();
        }

        public override string GetSummary() => "Wait for {Frames} frames";
    }
}
