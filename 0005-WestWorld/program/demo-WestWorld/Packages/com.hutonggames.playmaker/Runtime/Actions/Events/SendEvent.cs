using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Send an Event to the running FSM. The event is processed first by the current state, " +
                       "then any child states, and then the parent state.")]
    public class SendEvent : BaseDelayedEventAction
    {
        [Tooltip("The event to send.")]
        public EventRef Event;
        
        public override bool CanExecute() => Event.IsSet;

        public override void Execute()
        {
            if (!CheckTimer()) return;
            
            SendEvent(Event);
        }

        public override string GetSummary() => "Send {Event}" + base.GetSummary();
    }
}