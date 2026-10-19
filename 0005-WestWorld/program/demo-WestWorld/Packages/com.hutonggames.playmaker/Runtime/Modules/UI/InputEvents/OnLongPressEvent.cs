using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UGUIEvents
{
    [System.Serializable]
    [SystemEvent(SystemEvents.UIEventsRoot)]
    [Tooltip("Called when a pointer is held on the object for a short duration." + SystemEvents.UIEventsNotes)]
    public class OnLongPressEvent : BasePointerEvent<OnLongPressEvent, OnLongPressEventProxyComponent>
    {
    }

    public class OnLongPressEventProxyComponent : BaseInputProxyComponent,
        IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [SerializeField, Tooltip("Seconds to hold before long-press triggers.")]
        private float _holdSeconds = 0.45f;

        private bool _pressed;
        private bool _fired;
        private float _pressTime;
        private int _pointerId = int.MinValue;
        private PointerEventData _pressEventData;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData == null)
                return;

            _pointerId = eventData.pointerId;
            _pressEventData = eventData;
            _pressed = true;
            _fired = false;
            _pressTime = Time.unscaledTime;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!IsSamePointer(eventData))
                return;

            ResetState();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!IsSamePointer(eventData))
                return;

            ResetState();
        }

        private void Update()
        {
            if (!_pressed || _fired)
                return;

            if (Time.unscaledTime - _pressTime < _holdSeconds)
                return;

            _fired = true;
            _pressed = false;

            RaiseUpdated(_pressEventData);
        }

        protected override BaseEvent GetEvent(BaseEventData eventData) => OnLongPressEvent.Get(eventData);

        private bool IsSamePointer(PointerEventData eventData)
        {
            if (eventData == null)
                return false;

            return _pointerId == eventData.pointerId;
        }

        private void ResetState()
        {
            _pressed = false;
            _fired = false;
            _pointerId = int.MinValue;
            _pressEventData = null;
        }
    }
}
