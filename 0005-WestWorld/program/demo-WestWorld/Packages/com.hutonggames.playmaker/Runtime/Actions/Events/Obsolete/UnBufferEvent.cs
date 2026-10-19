using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Events)]
    [Obsolete("Use BufferedInput actions instead (this action does nothing)")]
    [ActionDescription("Remove buffering from an event.")]
    public class UnBufferEvent : BaseAction
    {
        [Tooltip("The event to remove buffering from.")]
        [SerializeField, EventNotSent]
        private EventRef _event;

        public override bool CanExecute() => CheckParameters(_event);

        public override void Execute()
        {
            Finish();
        }

        public override string GetSummary() => "UnBuffer {_event}";
    }
}