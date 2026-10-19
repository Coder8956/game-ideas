using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.Events)]
    [ConvertibleGroup(ConvertibleGroup.SendEvent)]
    [ActionDescription("Send an Event in the next frame.")]
    public class NextFrameEvent : BaseAction
    {
        public override UpdateMode RequiredUpdateModes => UpdateMode.EveryFrame;
        
        [Tooltip("The event to send.")]
        public EventRef Event;
        
        public override bool CanExecute() => Event.IsSet;

        private int _startFrame;

        public override void OnStart()
        {
            _startFrame = Time.frameCount;
        }

        public override void Execute()
        {
            if (Time.frameCount != _startFrame)
            {
                SendEvent(Event);
                Finish();
            }
        }

        public override string GetSummary() => "Next frame {Event}";
    }
}