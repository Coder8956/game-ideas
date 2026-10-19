using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayOrder(2)]
    public class SendEventToGameObjectBlock : BaseEventBlock
    {
        [GlobalEvent]
        [SerializeReference]
        [DisplayName("Send Event")]
        [Tooltip("Send event to a GameObject and optionally its children.\nNOTE: The Event must be global.")]
        public EventRef EventRef;

        [Tooltip("The GameObject to send the event to.")]
        public GameObjectVar Target;

        [Tooltip("Also send the event to all children of the targeted GameObject.")]
        public BoolVar SendToChildren;
        
        public override void Execute()
        {
            if (EventRef.IsNone || !Target.HasValue())
                return;
            
            //EventManager.BroadcastEvent(Target.Value, EventRef.BaseEvent, SendToChildren.Value);
        }
    }
}