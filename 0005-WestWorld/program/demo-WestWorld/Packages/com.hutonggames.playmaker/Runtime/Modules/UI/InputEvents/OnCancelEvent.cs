
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when the cancel button is pressed. " + SystemEvents.UIEventsNotes)]
    public class OnCancelEvent : BasePointerEvent<OnCancelEvent, OnCancelEventProxyComponent>
    {
    }
    
    public class OnCancelEventProxyComponent : BaseInputProxyComponent, ICancelHandler
    {
        public void OnCancel(BaseEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnCancelEvent.Get(eventData);
    }
    

    


}