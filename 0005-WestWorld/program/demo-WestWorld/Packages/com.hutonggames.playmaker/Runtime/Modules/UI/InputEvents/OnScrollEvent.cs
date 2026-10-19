using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when a mouse wheel scrolls." + SystemEvents.UIEventsNotes)]
    public class OnScrollEvent : BasePointerEvent<OnScrollEvent, OnScrollEventProxyComponent>
    {
    }
    
    public class OnScrollEventProxyComponent : BaseInputProxyComponent, IScrollHandler
    {
        public void OnScroll(PointerEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnScrollEvent.Get(eventData);
    }
    

    


}