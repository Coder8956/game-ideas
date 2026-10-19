using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.StateMachine)]
    [ActionDescription("Send an event to an FSM by name. <br/>In general you should prefer Global Events, " +
                       "but sometimes its convenient to send the event by name.")]
    public class SendFsmEvent : BaseAction
    {
        [Tooltip("The FSM to send the event to.")]
        [SerializeField]
        private BaseFsmComponentVar _fsmComponent;
        
        [Tooltip("The name of the event to send.")]
        [SerializeField]
        private StringVar _eventName;

        [OptionalField]
        [Tooltip("Optional delay before sending the event.")]
        [SerializeField]
        private FloatVar _delay;

        [Tooltip("Use unscaled realtime for the delay. When enabled, this delay is not affected by Time.timeScale.")]
        [SerializeField, DefaultValue(false)]
        private BoolVar _useRealtime;

        private float _timer;
        
        public override bool CanStart() => CheckParameters(_fsmComponent, _eventName, _useRealtime);

        public override bool CanExecute() => CheckParameters(_eventName, _useRealtime);
        
        public override void OnStart()
        {
            _timer = _delay.Value;
        }
        
        public override void Execute()
        {
            var fsm = _fsmComponent.Value;
            if (fsm == null) return;
            
            _timer -= _useRealtime.Value ? UnscaledDeltaTime : DeltaTime;
            Progress = 1 - _timer / _delay.Value;
            if (_timer > 0) return;
            
            fsm.SendEvent(_eventName.Value);
            
            if (!UsesEveryFrame)
            {
                Finish();
            }
        }

        protected override bool IsFinished() => _timer < 0 && !UsesEveryFrame;

        public override string GetSummary() => 
            "Send {_eventName} to {_fsmComponent}"  + (_delay.Value > 0  || _delay.IsVariable ? " in {Delay:seconds}" : "") +
            " {_useRealtime:option}";
    }
}
