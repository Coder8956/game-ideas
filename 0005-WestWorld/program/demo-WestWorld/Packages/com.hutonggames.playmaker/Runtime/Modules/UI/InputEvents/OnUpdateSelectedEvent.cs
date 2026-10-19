
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called on the selected object each tick." + SystemEvents.UIEventsNotes)]
    public class OnUpdateSelectedEvent : BasePointerEvent<OnUpdateSelectedEvent, OnUpdateSelectedEventProxyComponent>
    {
    }
    
    public class OnUpdateSelectedEventProxyComponent : BaseInputProxyComponent, IUpdateSelectedHandler
    {
        public void OnUpdateSelected(BaseEventData eventData) => RaiseUpdated(eventData);

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnUpdateSelectedEvent.Get(eventData);
    }
    

    


}