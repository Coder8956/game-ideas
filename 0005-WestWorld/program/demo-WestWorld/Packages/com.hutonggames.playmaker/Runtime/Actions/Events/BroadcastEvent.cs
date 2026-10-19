using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Broadcast a Global Event to all FSMs that receive the event.")]
    public class BroadcastEvent : BaseDelayedEventAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.Update;

        [GlobalEvent, BroadcastEvent]
        [Tooltip("The Global Event to send.")]
        public EventRef Event;

        [Tooltip("Do not send the event to self.")]
        public BoolVar ExcludeSelf;

        public override bool CanExecute() => CheckParameters(Event, ExcludeSelf) && Event.IsGlobalEvent;

        public override string ErrorCheck()
        {
            return !Event.IsGlobalEvent ? "Event must be a Global Event" : null;
        }
        

        public override void Execute()
        {
            if (!CheckTimer()) return;

            BroadcastEvent(Event);

            if (!ExcludeSelf.Value)
            {
                SendEvent(Event);
            }
        }

        public override string GetSummary() => 
            "Broadcast {Event}" + base.GetSummary() + "{ExcludeSelf:option}";
    }
}