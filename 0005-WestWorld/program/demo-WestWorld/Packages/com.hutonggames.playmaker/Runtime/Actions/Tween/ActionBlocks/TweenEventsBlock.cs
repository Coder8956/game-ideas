using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public class TweenEventsBlock : TweenActionBlock
    {
        [Tooltip("Send Event when the tween is finished.")]
        public EventRef FinishedEvent;

        public override void Execute()
        {
            if (TweenAction.Finished)
            {
                Action.SendEvent(FinishedEvent);
            }
        }
        
        public override string GetSummary() => "Finished {FinishedEvent}";
    }
}