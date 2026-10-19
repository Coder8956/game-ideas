using System;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Debug)]
    [ActionDescription("Debug the time spent in the current state.")]
    public class DebugStateTime : BaseDebugAction
    {
        public override void Execute()
        {
            Label.text = State.ActiveTime.ToString("0.00");
        }
    }
}