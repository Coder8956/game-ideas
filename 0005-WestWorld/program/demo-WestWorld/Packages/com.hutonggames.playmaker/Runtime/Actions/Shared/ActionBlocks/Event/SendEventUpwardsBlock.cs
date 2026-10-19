using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Event
{
    [Serializable]
    [DisplayOrder(1)]
    public class SendEventUpwardsBlock : BaseEventBlock
    {
        [GlobalEvent]
        [SerializeReference]
        [DisplayName("Send Event Upwards")]
        [Tooltip("Send event to this GameObject and its ancestors.\nNote: Event must be global.")]
        public EventRef EventRef;
        
        public override void Execute()
        {
            if (EventRef.IsNone)
                return;
            
            //EventManager.SendEventUpwards(Action.OwnerGameObject, EventRef.BaseEvent);
        }
    }
}