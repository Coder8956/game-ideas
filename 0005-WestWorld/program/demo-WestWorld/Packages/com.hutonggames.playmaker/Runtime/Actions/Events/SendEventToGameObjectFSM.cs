using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Send a Global Event to a named FSM Component on a GameObject.")]
    public class SendEventToGameObjectFSM : BaseDelayedEventAction
    {
        [GlobalEvent, ExternalEvent]
        [Tooltip("The Global Event to send.")]
        public EventRef Event;

        [Tooltip("The GameObject to send the Event to. ")]
        public GameObjectVar GameObject;

        [OptionalField]
        [Tooltip("The name of the FSM to target. If left empty it will use the first FSM Component found.")]
        public StringVar FsmName;

        public override bool CanExecute() => 
            CheckParameters(Event, GameObject) && Event.IsGlobalEvent;

        public override string ErrorCheck() => !Event.IsGlobalEvent ? "Event must be a Global Event!" : null;

        public override void Execute()
        {
            if (!CheckTimer()) return;
            
            var evt = Event.GetRuntimeEvent(new EventSender(this));
            ((GlobalEvent)Event.Event).SendToGameObjectFsm(evt, GameObject.Value, FsmName.Value);
        }
        
        public override string GetSummary()
        {
            var summary = "Send {Event} to {GameObject} ";
            
            if (FsmName.IsNotDefault())
            {
                summary += " FSM: {FsmName}";
            }
            else
            {
                summary += " (first FSM)";
            }

            summary += base.GetSummary();

            return summary;
        }
    }
}
