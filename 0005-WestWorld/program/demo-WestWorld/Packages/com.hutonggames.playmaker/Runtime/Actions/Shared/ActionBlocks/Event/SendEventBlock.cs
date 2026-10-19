using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [Serializable]
    [DisplayOrder(0)]
    public class SendEventBlock : BaseEventBlock
    {
        [SerializeReference, DisplayName("Send Event")]
        [Tooltip("Send local event.")]
        public EventRef EventRef;
        
        public override void Execute()
        {
            Action.SendEvent(EventRef);
        }
    }
}