using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Send a Global Event to all FSM Components on a GameObject.")]
    public class SendEventToGameObject : BaseDelayedEventAction
    {
        [GlobalEvent, ExternalEvent]
        [Tooltip("The Global Event to send.")]
        public EventRef Event;

        [Tooltip("The GameObject to send the Event to. ")]
        public GameObjectVar GameObject;

        [Tooltip("Also send the Event to children of the GameObject.<br/>NOTE: This is more expensive!")]
        public BoolVar AlsoSendToChildren;

        public override bool CanExecute() => 
            CheckParameters(Event, GameObject, AlsoSendToChildren) && Event.IsGlobalEvent;

        public override string ErrorCheck() => !Event.IsGlobalEvent ? "Event must be a Global Event!" : null;
        

        public override void Execute()
        {
            if(!CheckTimer()) return;
            
            var evt = Event.GetRuntimeEvent(new EventSender(this));
            ((GlobalEvent)Event.Event).SendToGameObject(evt, GameObject.Value, AlsoSendToChildren.Value);
        }
        
        public override string GetSummary()
        {
            var summary = "Send {Event} to {GameObject}" + base.GetSummary();
            
            if (AlsoSendToChildren.Value)
            {
                summary += " and children";
            }

            summary += base.GetSummary();

            return summary;
        }
    }
}
