using HutongGames.Extensions;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Send a Global Event to multiple FSM Components.")]
    public class SendEventToFsmComponents : BaseDelayedEventAction
    {

        [GlobalEvent, ExternalEvent]
        [Tooltip("The Global Event to send.")]
        public EventRef Event;

        [Tooltip("The FSM Components to send the Event to. ")]
        public BaseFsmComponentListVar FsmComponents;

        public override bool CanExecute() => 
            CheckParameters(Event, FsmComponents) && Event.IsGlobalEvent;

        public override string ErrorCheck() => !Event.IsGlobalEvent ? "Event must be a Global Event!" : null;

        public override void Execute()
        {
            if(!CheckTimer()) return;
            
            var evt = Event.GetRuntimeEvent(new EventSender(this));
            ((GlobalEvent)Event.Event).SendToFsmComponents(evt, FsmComponents.Value);
        }

        public override string GetSummary() => 
            "Send {Event} to {FsmComponents}" + base.GetSummary();
    }
}
