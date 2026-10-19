using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Send events based on the active state of a target FSM.")]
    public class FsmStateSwitch : BaseAction
    {
        [Tooltip("The FSM to check.")]
        [SerializeField]
        private BaseFsmComponentVar _fsmComponent;

        [Tooltip("Send events based on the FSM's active state.")]
        [SerializeField]
        private FsmStateEventSwitch _switch;
        
        [Tooltip("Use full path to match sub-states (e.g., Walking/Slow, Walking/Fast). Otherwise use only the state name (e.g., Slow, Fast)")]
        [SerializeField, DefaultValue(true)]
        private BoolVar _useFullPath;

        public override void Execute()
        {
            if (!RuntimeCheck(_fsmComponent)) return;

            var evt = _switch.Evaluate(_fsmComponent.Fsm, _useFullPath.Value);
            SendEvent(evt);
        }
        
        public override string GetSummary() => "{_fsmComponent} Switch: " + _switch?.GetSummary();
 
#if UNITY_EDITOR        
        public override bool HasDebugInfo => true;

        public override string GetDebugInfo()
        {
            if (_fsmComponent.Fsm == null) return null;
            var activeStates = _fsmComponent.Fsm.GetActiveStateNames(true);
            if (activeStates.Count > 0)
            {
                return string.Join("\n", activeStates);
            }

            return Strings.NotActiveLabel;
        }
        
#endif        
    }
}
