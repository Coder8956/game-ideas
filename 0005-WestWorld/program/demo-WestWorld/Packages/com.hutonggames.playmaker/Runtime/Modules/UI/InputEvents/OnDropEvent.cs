using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called on the object where a drag finishes." + SystemEvents.UIEventsNotes)]
    public class OnDropEvent : BasePointerEvent<OnDropEvent, OnDropEventProxyComponent>
    {
    }
    
    public class OnDropEventProxyComponent : BaseInputProxyComponent, IDropHandler
    {
        public void OnDrop(PointerEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnDropEvent.Get(eventData);
    }
    

    


}