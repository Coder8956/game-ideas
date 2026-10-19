using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when a pointer is pressed and released on the same object." + SystemEvents.UIEventsNotes)]
    public class OnPointerClickEvent : BasePointerEvent<OnPointerClickEvent, OnPointerClickEventProxyComponent>
    {
    }
    
    public class OnPointerClickEventProxyComponent : BaseInputProxyComponent, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnPointerClickEvent.Get(eventData);
    }
}