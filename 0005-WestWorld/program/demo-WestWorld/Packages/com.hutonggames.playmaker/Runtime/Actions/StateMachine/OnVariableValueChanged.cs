using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Send an event when a variable value changes." +
                       "<br/>This can be useful to respond to external changes, " +
                       "e.g., from Set FSM Variable actions, external scripts, or even other regions in the FSM.")]
    public class OnVariableValueChanged : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
        
        [SerializeReference]
        [BaseType(typeof(object))]
        [Tooltip("The variable to check for changes.")]
        private AnyVariableRef _variable;

        [Tooltip("Event to send when the value changes.")]
        [SerializeField]
        private EventRef _event;
        
        public override bool CanExecute() => !_variable.IsNone && CheckParameter(_event);

        public override void OnStart()
        {
            _variable.Variable.ValueChanged += OnValueChanged;
        }
        
        private void OnValueChanged()
        {
            SendEvent(_event);
        }
        
        public override void OnStop()
        {
            _variable.Variable.ValueChanged -= OnValueChanged;
        }
        

        public override string GetSummary() => "On {_variable} changed {_event}";
    }
}