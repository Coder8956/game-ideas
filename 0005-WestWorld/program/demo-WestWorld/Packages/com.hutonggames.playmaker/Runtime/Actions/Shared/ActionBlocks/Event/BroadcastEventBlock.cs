using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Event
{
    [Serializable]
    [DisplayOrder(3)]
    public class BroadcastEventBlock : BaseEventBlock
    {
        [GlobalEvent]
        [SerializeReference]
        [DisplayName("Broadcast Event")]
        [Tooltip("Broadcast event to all active FSMs.\nNote: Event must be global.")]
        public EventRef EventRef;
        
        public override void Execute()
        {
            if (EventRef.IsNone)
                return;
            
            //EventManager.BroadcastAll(EventRef.BaseEvent);
        }
    }
}