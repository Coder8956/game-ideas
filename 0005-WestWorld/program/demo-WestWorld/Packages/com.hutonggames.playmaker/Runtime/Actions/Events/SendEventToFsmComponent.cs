using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Send a Global Event to a specific FSM Component.")]
    public class SendEventToFsmComponent : BaseDelayedEventAction
    {

        [GlobalEvent, ExternalEvent]
        [Tooltip("The Global Event to send.")]
        public EventRef Event;

        [Tooltip("The FSM Component to send the Event to." +
                 "\nNOTE: This can be an FSM Component or an FSM Template Component.")]
        public BaseFsmComponentVar FsmComponent;

        public override bool CanExecute() => 
            CheckParameters(Event, FsmComponent) && Event.IsGlobalEvent;

        public override string ErrorCheck() => !Event.IsGlobalEvent ? "Event must be a Global Event!" : null;
        
        public override void Execute()
        {
            if (!CheckTimer()) return;
            
            var evt = Event.GetRuntimeEvent(new EventSender(this));
            ((GlobalEvent)Event.Event).SendToFsmComponent(evt, FsmComponent.Value);
        }

        public override string GetSummary() => 
            "Send {Event} to {FsmComponent}" + base.GetSummary();
    }
}
