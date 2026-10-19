using HutongGames.Extensions;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Send a Global Event to all FSM Components on children of a GameObject.")]
    public class SendEventToChildren : BaseDelayedEventAction
    {

        [GlobalEvent, ExternalEvent]
        [Tooltip("The Global Event to send.")]
        public EventRef Event;

        [Tooltip("The GameObject to send the Event to. ")]
        public GameObjectVar Parent;

        public override bool CanExecute() => CheckParameters(Event, Parent) && Event.IsGlobalEvent;

        public override string ErrorCheck() => !Event.IsGlobalEvent ? "Event must be a Global Event!" : null;

        public override void Execute()
        {
            if (!CheckTimer()) return;
            
            var evt = Event.GetRuntimeEvent(new EventSender(this));
            ((GlobalEvent)Event.Event).SendToChildren(evt, Parent.Value);
        }

        public override string GetSummary() => 
            "Send {Event} to {Parent} children" + base.GetSummary();
    }
}
