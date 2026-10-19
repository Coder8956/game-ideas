using System;
using UnityEngine;
using HutongGames.PlayMaker.FSM;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Transition directly to another state.")]
    public class GotoState : BaseAction, IGotoState
    {
        [Tooltip("The state to transition to.")]
        [SerializeReference]
        private StateNode  _toState;

        public StateNode ToState => _toState;

        public override void Execute() => State.GotoState(_toState);

        public override string GetSummary() => "Goto {_toState}";
    }
}
