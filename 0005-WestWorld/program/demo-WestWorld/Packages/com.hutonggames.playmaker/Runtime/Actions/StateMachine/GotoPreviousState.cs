using System;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Transition directly to the previously active state in the current region.")]
    public class GotoPreviousState : BaseAction
    {
        public override void Execute()
        {
            State?.GotoPreviousState();
        }

        public override string GetSummary() => "Goto previous state";
    }
}
