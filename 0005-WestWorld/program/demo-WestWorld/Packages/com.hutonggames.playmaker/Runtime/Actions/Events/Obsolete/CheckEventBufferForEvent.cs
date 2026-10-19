using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [ActionCategory(Category.Events)]
    [Obsolete("Use BufferedInput actions instead (this action does nothing)")]
    [ActionDescription("Check the event buffer for a recently sent event. " +
                       "\n\nUse <b>Buffer Event</b> to mark an event as buffered.")]
    public class CheckEventBufferForEvent : BaseTrueFalseAction
    {
        
        [Tooltip("The event to check for.")]
        [SerializeField]
        private EventRef _event;
        
        [OptionalField]
        [Tooltip("Maximum age of the event in seconds.")]
        [SerializeField, DefaultValue(0.2f)]
        private FloatVar _maxAge;
        
        public override bool CanExecute() => CheckParameters(_event, _maxAge) && base.CanExecute();
        protected override bool Test() => false;

        protected override string TrueSummary => "Buffered {_event} found";
        protected override string FalseSummary => "Buffered {_event} not found";
    }
}