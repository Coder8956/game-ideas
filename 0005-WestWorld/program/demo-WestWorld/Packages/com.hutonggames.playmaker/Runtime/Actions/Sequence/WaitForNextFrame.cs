using System;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Sequence)]
    [ActionDescription("Wait until next frame. Useful in loops that might otherwise loop infinitely.")]
    public class WaitForNextFrame : BaseWaitAction
    {
        [NonSerialized] private bool _finished;

        public override void OnStart()
        {
            _finished = false;
        }

        public override void Execute()
        {
            if (_finished && CurrentUpdateMode == UpdateMode.Update)
            {
                Finish();
            }

            _finished = true;
        }
        
        public override string GetSummary() => "Wait for next frame";
    }
}

