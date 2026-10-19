
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when a move event occurs (left, right, up, down). " + SystemEvents.UIEventsNotes)]
    public class OnMoveEvent : BasePointerEvent<OnMoveEvent, OnMoveEventProxyComponent>
    {
    }
    
    public class OnMoveEventProxyComponent : BaseInputProxyComponent, IMoveHandler
    {
        public void OnMove(AxisEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnMoveEvent.Get(eventData);
    }
    

    


}