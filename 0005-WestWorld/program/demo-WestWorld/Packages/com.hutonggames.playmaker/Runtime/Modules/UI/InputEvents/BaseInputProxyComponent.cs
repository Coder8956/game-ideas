using System;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    public abstract class BaseInputProxyComponent : BaseProxyEventComponent
    {
        public event Action<BaseEventData> Updated;
        
        protected void RaiseUpdated(BaseEventData eventData)
        {
            Updated?.Invoke(eventData);

            if (SubscriberCount > 0)
            {
                var clickEvent = GetEvent(eventData);
                SendEvent(clickEvent);
            }
        }
        
        protected abstract BaseEvent GetEvent(BaseEventData eventData);
    }
}