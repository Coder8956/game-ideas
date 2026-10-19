using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Events)]
    [Obsolete("Use BufferedInput actions instead (this action does nothing)")]
    [ActionDescription("Mark an event as buffered." +
                       "\n\nWhen a buffered event is sent and not handled, it is added to a buffer that lasts 2 seconds. " +
                       "Use Send Buffered Event to check this buffer and send the event if it's within the time window.")]
    public class BufferEvent : BaseAction
    {
        [Tooltip("The event to mark as buffered.")]
        [SerializeField, EventNotSent]
        private EventRef _event;

        public override bool CanExecute() => CheckParameters(_event);

        public override void Execute()
        {
            Finish();
        }

        public override string GetSummary() => "Buffer {_event}";
    }
}