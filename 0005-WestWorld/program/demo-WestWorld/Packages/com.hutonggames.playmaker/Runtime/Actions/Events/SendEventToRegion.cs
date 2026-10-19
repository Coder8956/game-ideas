using JetBrains.Annotations;
using HutongGames.PlayMaker.FSM;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Send an Event directly to a specific Region in the running FSM. " +
                       "Only the selected Region processes the event.")]
    public class SendEventToRegion : BaseDelayedEventAction
    {
        [Tooltip("The event to send.")]
        public EventRef Event;

        [Tooltip("The Region to send the Event to.")]
        [SerializeReference]
        public RegionNode Region;

        public override bool CanExecute() => Event is { IsSet: true } && Region != null;

        public override string ErrorCheck()
        {
            if (Region == null)
            {
                return "Missing target Region.";
            }

            return State != null && Region.Fsm != State.Fsm
                ? "Target Region must belong to the same FSM."
                : null;
        }

        public override void Execute()
        {
            if (!CheckTimer()) return;
            if (Region == null) return;

            var evt = Event.GetRuntimeEvent(new EventSender(this));
            Region.SendEvent(evt);
        }

        public override string GetSummary() => "Send {Event} to {Region}" + base.GetSummary();
    }
}
