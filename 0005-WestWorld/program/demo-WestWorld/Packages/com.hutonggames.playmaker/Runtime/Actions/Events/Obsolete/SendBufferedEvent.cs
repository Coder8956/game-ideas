using System;
using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [Obsolete("Use BufferedInput actions instead (this action does nothing)")]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Check the event buffer for a recent event. If found, send the event.")]
    public class SendBufferedEvent : BaseAction
    {
        [Tooltip("The event to check for.")]
        [SerializeField]
        private EventRef _event;

        [OptionalField]
        [Tooltip("Maximum age of the event in seconds.")]
        [SerializeField, DefaultValue(0.2f)]
        private FloatVar _maxAge;

        public override bool CanExecute() => CheckParameters(_event, _maxAge);

        public override void Execute()
        {
            Finish();
        }

        public override string GetSummary() => "Send {_event} if buffered in last {_maxAge:seconds}";
    }
}