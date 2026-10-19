using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when a pointer is released (called on the GameObject that the pointer is clicking)." + SystemEvents.UIEventsNotes)]
    public class OnPointerUpEvent : BasePointerEvent<OnPointerUpEvent, OnPointerUpEventProxyComponent>
    {
    }
    
    public class OnPointerUpEventProxyComponent : BaseInputProxyComponent, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnPointerUpEvent.Get(eventData);
    }

}