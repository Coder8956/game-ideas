using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called on the drag object when dragging is about to begin." + SystemEvents.UIEventsNotes)]
    public class OnBeginDragEvent : BasePointerEvent<OnBeginDragEvent, OnBeginDragEventProxyComponent>
    {
    }
    
    public class OnBeginDragEventProxyComponent : BaseInputProxyComponent, IBeginDragHandler, IDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnBeginDragEvent.Get(eventData);
        public void OnDrag(PointerEventData eventData)
        {
            // We need to implement this to get OnBeginDrag events
        }
    }

}