using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Events)]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Send an Event by name. " +
                       "Generally you should prefer other event actions, " +
                       "but sometimes it's useful to be able to send events by name. " +
                       "NOTE: this is less performant, and if an event name changes you will need to change it here also.")]
    public class SendEventByName : BaseDelayedEventAction
    {
        [SerializeField] private EventTarget _eventTarget;

        [Tooltip("The name of the event to send")]
        [SerializeField]
        private StringVar _eventName;

        
        public override void Execute()
        {
            if (!CheckTimer()) return;
            
            _eventTarget.SendEvent(_eventName.Value, State);
        }

        public override string GetSummary() => "Send {_eventName}" + base.GetSummary();
    }
}