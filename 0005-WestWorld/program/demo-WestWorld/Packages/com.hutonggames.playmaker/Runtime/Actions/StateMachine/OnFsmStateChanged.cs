using HutongGames.PlayMaker.FSM;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Send an event when the state of an FSM changes.")]
    public class OnFsmStateChanged : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
        
        [Tooltip("The FSM Component to check for changes.")]
        [SerializeField]
        private FsmComponentVar _fsmComponent;

        [Tooltip("Event to send when the FSM state changes.")]
        [SerializeField]
        private EventRef _event;
        
        public override bool CanExecute() => CheckParameters(_fsmComponent, _event);

        public override void OnStart()
        { 
            AddCallback();

            if (_fsmComponent.IsVariable)
            {
                _fsmComponent.Variable.ValueChanged += UpdateFsm;;
            }
        }
        
        public override void OnStop()
        {
            RemoveCallback();
            
            if (_fsmComponent.IsVariable)
            {
                _fsmComponent.Variable.ValueChanged -= UpdateFsm;;
            }
        }

        private void UpdateFsm()
        {
            AddCallback();
            OnStateChanged();
        }
        
        private void OnStateChanged()
        {
            QueueEvent(_event);
        }
        
        private FsmNode _currentFsmNode;
        
        private void AddCallback()
        {
            if (_currentFsmNode != null) RemoveCallback();
            var value = _fsmComponent.Value;
            _currentFsmNode = value ? value.Fsm : null;
            if (_currentFsmNode == null) return;
            _currentFsmNode.StateChanged += OnStateChanged;
        }

        private void RemoveCallback()
        {
            if (_currentFsmNode == null) return;
            _currentFsmNode.StateChanged -= OnStateChanged;
        }
        
        public override string GetSummary() => "On {_fsmComponent} state changed {_event}";
    }
}