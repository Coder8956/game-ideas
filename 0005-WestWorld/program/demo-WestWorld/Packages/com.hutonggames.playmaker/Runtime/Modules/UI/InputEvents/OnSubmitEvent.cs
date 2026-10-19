
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when the submit button is pressed. " + SystemEvents.UIEventsNotes)]
    public class OnSubmitEvent : BasePointerEvent<OnSubmitEvent, OnSubmitEventProxyComponent>
    {
    }
    
    public class OnSubmitEventProxyComponent : BaseInputProxyComponent, ISubmitHandler
    {
        public void OnSubmit(BaseEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnSubmitEvent.Get(eventData);
    }
    

    


}