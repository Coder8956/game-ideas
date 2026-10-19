
using HutongGames.PlayMaker.Internal;
using HutongGames.PlayMaker.UGUIEvents;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions.EventSystems
{
    [System.Serializable]
    public abstract class BasePointerEventAction<T> : BaseAction where T : BaseInputProxyComponent
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
        
        [OptionalField]
        [Tooltip("Event to send.")] 
        [SerializeField] 
        protected EventRef _sendEvent;
        
        [WriteOnly, OptionalField]
        [Tooltip("Store the PointerEventData in a variable.")]
        [SerializeField, DisplayName("Get PointerEventData")]
        protected PointerEventDataRef _pointerEventData;

        private T _proxyComponent;
        
        public override void OnStart()
        {
            _proxyComponent ??= OwnerGameObject.GetOrAddComponent<T>();
            _proxyComponent.Updated += HandleEvent;
        }
        
        public override void OnStop()
        {
            _proxyComponent.Updated -= HandleEvent;
        }
        
        protected virtual bool PassesFilters(PointerEventData e) => true;

        private void HandleEvent(BaseEventData eventData)
        {
            if (eventData is not PointerEventData ped)
                return;

            if (!PassesFilters(ped))
                return;

            _pointerEventData.Value = ped;
            SendEvent(_sendEvent);
        }
        
        public override string GetSummary()
        {
            var summary = Nicify.NicifyName(GetType().Name.TrimEnd("Event"));
            
            if (_sendEvent.Event != null)   
            {
                summary += " {_sendEvent}";
            }
            
            if (_pointerEventData.IsAssigned)
            {
                summary += " -> {_pointerEventData}";
            }

            return summary;
        }
    }
}
