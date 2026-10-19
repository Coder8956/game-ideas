using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMaker.UGUIEvents;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Touch-first long-press requests a single action (commonly ContextMenu).
    /// Uses RequireDirectHit to avoid firing when another UI element is on top.
    /// Also forwards OnLongPress system event to the item GameObject.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Data Item Long Press Action")]
    [Icon(Strings.EditorIconsPath + "DataRowSelectionIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-item-long-press-action/")]
    public sealed class DataItemLongPressAction : DataItemActionBase,
        IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        [FormerlySerializedAs("_actionType")]
        [SerializeField, Tooltip("Action to request on long-press.")]
        private DataUICommand _command = DataUICommand.ContextMenu;

        [SerializeField, Tooltip("Seconds to hold before long-press triggers.")]
        private float _holdSeconds = 0.45f;

        [SerializeField, Tooltip(
            "Only trigger when this GameObject is the direct UI raycast hit.\n\n" +
            "When enabled, this action will NOT fire if another UI element is on top of this one " +
            "(e.g. buttons, overlays, icons, or other graphics).\n\n" +
            "Disable this if you want clicks anywhere over this hierarchy to trigger the action.")]
        private bool _requireDirectHit = true;

        private bool _pressed;
        private bool _fired;
        private float _pressTime;
        private int _pointerId = int.MinValue;

        // Captured on down so long-press isn't affected by hover changes during hold.
        private bool _directHitOnDown;
        private PointerEventData _pressEventData;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData == null)
                return;

            _pointerId = eventData.pointerId;
            _pressed = true;
            _fired = false;
            _pressTime = Time.unscaledTime;
            _pressEventData = eventData;

            _directHitOnDown = !_requireDirectHit || IsDirectHit(eventData);
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

            if (!_directHitOnDown)
                return;

            if (Time.unscaledTime - _pressTime < _holdSeconds)
                return;

            _fired = true;
            _pressed = false;

            TryRequest(command: _command);
            SendItemSystemEvent(OnLongPressEvent.Get(_pressEventData));
        }

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
            _directHitOnDown = false;
            _pressEventData = null;
        }
    }
}

