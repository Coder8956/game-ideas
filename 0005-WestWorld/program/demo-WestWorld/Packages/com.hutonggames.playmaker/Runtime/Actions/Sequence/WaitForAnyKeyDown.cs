using System;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Sequence)]
    [ActionDescription("Wait for any key, mouse button, or touch to be pressed.")]
    public class WaitForAnyKeyDown : BaseWaitAction
    {
        [NonSerialized] private bool _finished;
        
        public override void OnStart()
        {
            _finished = false;
        }
        
        public override void Execute()
        {
            // Wait a frame so chained WaitForAnyKeyDown
            // actions don't all finish on the same frame
            
            if (_finished && CurrentUpdateMode == UpdateMode.Update)
            {
                Finish();
            }

            if (InputShim.AnyKeyDown() || InputShim.AnyTouchDown())
            {
                _finished = true;
            }
        }
    }
}
