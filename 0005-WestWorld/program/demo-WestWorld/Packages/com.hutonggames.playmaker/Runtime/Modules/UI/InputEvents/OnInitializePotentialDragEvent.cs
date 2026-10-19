using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when a drag target is found, can be used to initialize values." + SystemEvents.UIEventsNotes)]
    public class OnInitializePotentialDragEvent : BasePointerEvent<OnInitializePotentialDragEvent, OnInitializePotentialDragEventProxyComponent>
    {
    }
    
    public class OnInitializePotentialDragEventProxyComponent : BaseInputProxyComponent, IInitializePotentialDragHandler
    {
        public void OnInitializePotentialDrag(PointerEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnInitializePotentialDragEvent.Get(eventData);
    }

}