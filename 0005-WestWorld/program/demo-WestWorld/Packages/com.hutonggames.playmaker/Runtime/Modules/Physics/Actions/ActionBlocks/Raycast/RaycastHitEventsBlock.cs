using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    public class RaycastHitEventsBlock : BaseActionBlock
    {
        [OptionalField]
        [Tooltip("Event to send if the ray hits something.")]
        public EventRef HitEvent;

        [OptionalField]
        [Tooltip("Event to send if the ray doesn't hit something.")]
        public EventRef NotHitEvent;
        
        public override string GetSummary()
        {
            var output = ""; 
            output += $"Hit Event: {HitEvent}";
            output += $"NotHit Event: {NotHitEvent}";

            return output;
        }
    }
}