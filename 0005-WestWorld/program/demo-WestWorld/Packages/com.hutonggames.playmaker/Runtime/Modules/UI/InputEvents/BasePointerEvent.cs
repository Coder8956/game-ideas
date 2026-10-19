using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    public class BasePointerEvent<TEvent, TProxyComponent> : BaseSystemProxyEvent<TEvent, TProxyComponent>, IHasInputEventData
        where TProxyComponent : BaseProxyEventComponent 
        where TEvent : new()
    {
        public static TEvent Get(BaseEventData eventData)
        {
            ((IHasInputEventData)Instance).EventData = eventData;
            return Instance;
        }
        
        public BaseEventData EventData { get; set; }
        
        public override BaseEventDataGetter GetEventDataGetter() => new PointerEventDataGetter();
    }
}
