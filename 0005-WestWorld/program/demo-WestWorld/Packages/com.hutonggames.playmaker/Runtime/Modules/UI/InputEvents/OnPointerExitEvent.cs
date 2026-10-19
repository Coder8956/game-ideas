using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when a pointer Exits the object." + SystemEvents.UIEventsNotes)]
    public class OnPointerExitEvent : BasePointerEvent<OnPointerExitEvent, OnPointerExitEventProxyComponent>
    {
    }
    
    public class OnPointerExitEventProxyComponent : BaseInputProxyComponent, IPointerExitHandler
    {
        public void OnPointerExit(PointerEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnPointerExitEvent.Get(eventData);
    }

}