using System;
using JetBrains.Annotations;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable, PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Finish the state and send FINISHED event, even if sub states are still running. Loops are completed first.")]
    public class FinishState : BaseAction
    {
        public override void Execute()
        {
            if (State.ActionList.Loop.IsLooping)
            {
                // Loop will run this action again
                Finish();
                return;
            }
            
            State.Finish();
        }
    }
}