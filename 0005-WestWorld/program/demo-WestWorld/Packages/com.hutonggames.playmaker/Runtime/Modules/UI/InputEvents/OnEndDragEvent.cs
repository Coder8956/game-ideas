using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called on the drag object when a drag finishes." + SystemEvents.UIEventsNotes)]
    public class OnEndDragEvent : BasePointerEvent<OnEndDragEvent, OnEndDragEventProxyComponent>
    {
    }
    
    public class OnEndDragEventProxyComponent : BaseInputProxyComponent, IEndDragHandler
    {
        public void OnEndDrag(PointerEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnEndDragEvent.Get(eventData);
    }

}