using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when a pointer is pressed on the object." + SystemEvents.UIEventsNotes)]
    public class OnPointerDownEvent : BasePointerEvent<OnPointerDownEvent, OnPointerDownEventProxyComponent>
    {
    }
    
    public class OnPointerDownEventProxyComponent : BaseInputProxyComponent, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnPointerDownEvent.Get(eventData);
    }
}