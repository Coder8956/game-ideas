using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when a pointer enters the object." + SystemEvents.UIEventsNotes)]
    public class OnPointerEnterEvent : BasePointerEvent<OnPointerEnterEvent, OnPointerEnterEventProxyComponent>
    {
    }
    
    public class OnPointerEnterEventProxyComponent : BaseInputProxyComponent, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnPointerEnterEvent.Get(eventData);
    }

}