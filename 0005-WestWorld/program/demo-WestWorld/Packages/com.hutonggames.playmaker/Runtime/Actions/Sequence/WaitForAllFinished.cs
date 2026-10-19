using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Sequence)]
    [ActionDescription("Wait for all running actions in this state to finish.")]
    public class WaitForAllFinished : BaseWaitAction
    {
        [Tooltip("Only wait for actions that can finish. \n\nFor example, a <b>Move Towards</b> action can finish, " +
                 "but other actions in the list might be just updating properties every frame, and can't finish. " +
                 "In this case, set this to true to only wait for the <b>Move Towards</b> to finish.")]
        [SerializeField]
        private bool _onlyActionsThatCanFinish;
        
        public override void Execute()
        {
            // Note this action is running,
            // so we're checking for more than one active action.
            
            var activeCount = _onlyActionsThatCanFinish
                ? State.ActionList.CountActiveActionsThatCanFinish() 
                : State.ActionList.ActiveActionsCount;
            
            if (activeCount == 1)
            {
                Finish();
            }
        }
        
        public override string GetSummary() => "Wait for all actions to finish";
    }
}

