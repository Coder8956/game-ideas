
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when the object becomes the selected object. " + SystemEvents.UIEventsNotes)]
    public class OnSelectEvent : BasePointerEvent<OnSelectEvent, OnSelectEventProxyComponent>
    {
    }
    
    public class OnSelectEventProxyComponent : BaseInputProxyComponent, ISelectHandler
    {
        public void OnSelect(BaseEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnSelectEvent.Get(eventData);
    }
    

    


}