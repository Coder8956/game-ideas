using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called on the drag object when a drag is happening." + SystemEvents.UIEventsNotes)]
    public class OnDragEvent : BasePointerEvent<OnDragEvent, OnDragEventProxyComponent>
    {
    }
    
    public class OnDragEventProxyComponent : BaseInputProxyComponent, IDragHandler
    {
        public void OnDrag(PointerEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnDragEvent.Get(eventData);
    }

}