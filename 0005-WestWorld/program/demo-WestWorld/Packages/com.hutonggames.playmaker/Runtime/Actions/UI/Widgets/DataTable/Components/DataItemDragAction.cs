using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMaker.UGUIEvents;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Sends data commands for the drag lifecycle:
    /// Begin Drag, End Drag, and Cancel Drag.
    /// Commands can be disabled by selecting "None".
    /// Also forwards PlayMaker UGUI drag system events to the item GameObject.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Data Item Drag Action")]
    [Icon(Strings.EditorIconsPath + "DataRowSelectionIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-item-drag-action/")]
    public sealed class DataItemDragAction : DataItemActionBase,
        IPointerDownHandler, IPointerUpHandler,
        IInitializePotentialDragHandler,
        IBeginDragHandler, IDragHandler, IEndDragHandler,
        IPointerExitHandler
    {
        [SerializeField] private DataUICommand _beginCommand = DataUICommand.BeginDrag;
        [SerializeField] private DataUICommand _updateCommand = DataUICommand.DragUpdate;
        [SerializeField] private DataUICommand _endCommand = DataUICommand.EndDrag;
        [SerializeField] private DataUICommand _cancelCommand = DataUICommand.CancelDrag;

        [SerializeField] private bool _cancelOnPointerExit = true;

        // If true, drag begins immediately (no pixel threshold). Great for drag handles.
        [SerializeField] private bool _disableDragThreshold = true;

        private bool _pressed;
        private bool _didBeginDrag;
        private int _pointerId = int.MinValue;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData == null)
                return;

            // Only start a drag if the pointer DOWN happened on this exact handle.
            // This avoids flaky pointerPress/pointerDrag routing later.
            if (!IsDirectHit(eventData))
                return;

            _pressed = true;
            _didBeginDrag = false;
            _pointerId = eventData.pointerId;
        }

        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            if (eventData == null)
                return;

            if (_disableDragThreshold && IsSamePointer(eventData) && _pressed)
                eventData.useDragThreshold = false;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!IsSamePointer(eventData) || !_pressed)
                return;

            _didBeginDrag = true;
            TryRequest(_beginCommand, eventData);
            SendItemSystemEvent(OnBeginDragEvent.Get(eventData));
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!IsSamePointer(eventData) || !_didBeginDrag)
                return;

            // Host uses this to move the overlay row + placeholder.
            TryRequest(_updateCommand, eventData);
            SendItemSystemEvent(OnDragEvent.Get(eventData));
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (!IsSamePointer(eventData))
                return;

            if (_didBeginDrag)
            {
                TryRequest(_endCommand, eventData);
                SendItemSystemEvent(OnEndDragEvent.Get(eventData));
            }

            ResetState();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!IsSamePointer(eventData))
                return;

            // Fallback: some setups don't reliably call OnEndDrag.
            if (_didBeginDrag)
            {
                TryRequest(_endCommand, eventData);
                SendItemSystemEvent(OnEndDragEvent.Get(eventData));
            }
            else
            {
                TryRequest(_cancelCommand, eventData);
            }

            ResetState();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!IsSamePointer(eventData))
                return;

            if (_cancelOnPointerExit && !_didBeginDrag && _pressed)
            {
                TryRequest(_cancelCommand, eventData);
                ResetState();
            }
        }

        private bool IsSamePointer(PointerEventData eventData)
        {
            return eventData != null && eventData.pointerId == _pointerId;
        }

        private void ResetState()
        {
            _pressed = false;
            _didBeginDrag = false;
            _pointerId = int.MinValue;
        }
    }
}
