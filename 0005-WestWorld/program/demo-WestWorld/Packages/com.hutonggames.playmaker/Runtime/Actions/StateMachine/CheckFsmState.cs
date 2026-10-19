using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Check if an FSM is in a given state.")]
    public class CheckFsmState : BaseTrueFalseAction
    {
        [Tooltip("The FSM to check.")]
        [SerializeField]
        private BaseFsmComponentVar _fsmComponent;
        
        [Tooltip("The state to check (e.g., Idle, Walking, Running.)")]
        [SerializeField]
        private StringVar _state;

        [Tooltip("Use full path to match sub-states (e.g., Walking/Slow, Walking/Fast). Otherwise use only the state name (e.g., Slow, Fast)")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _useFullPath;

        public override bool CanStart() => CheckParameters(_fsmComponent, _state);
        
        public override bool CanExecute() => true;
        
        protected override bool Test()
        {
            if (!_fsmComponent.Value || _fsmComponent.Value.Fsm == null) return false;
            return _fsmComponent.Value.Fsm.IsActiveStateName(_state.Value, _useFullPath.Value);
        }

        protected override string TrueSummary => "{_fsmComponent} is in state {_state}";
        protected override string FalseSummary => "{_fsmComponent} is not in state {_state}";
    }
}