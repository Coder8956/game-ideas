
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called on the selected object becomes deselected. " + SystemEvents.UIEventsNotes)]
    public class OnDeselectEvent : BasePointerEvent<OnDeselectEvent, OnDeselectEventProxyComponent>
    {
    }
    
    public class OnDeselectEventProxyComponent : BaseInputProxyComponent, IDeselectHandler
    {
        public void OnDeselect(BaseEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnDeselectEvent.Get(eventData);
    }
    

    


}