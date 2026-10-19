using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Bridges EventSystem selection to Data UI selection.
    /// Attach this to a row object that is also a Selectable (e.g. Button).
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Data Item Select On Navigation")]
    [Icon(Strings.EditorIconsPath + "DataRowSelectionIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-item-selection/")]
    public sealed class DataItemSelectOnNavigation : DataItemActionBase, ISelectHandler
    {
        private bool _hadFocusInsideRow;

        private void OnEnable()
        {
            _hadFocusInsideRow = false;
        }

        private void LateUpdate()
        {
            bool hasFocusInsideRow = IsEventSystemFocusInsideRow();
            if (ShouldHandleSelectOnNavigation() && hasFocusInsideRow && !_hadFocusInsideRow)
                TryRequest(DataUICommand.Select);

            _hadFocusInsideRow = hasFocusInsideRow;
        }

        public void OnSelect(BaseEventData eventData)
        {
            _hadFocusInsideRow = true;
            if (!ShouldHandleSelectOnNavigation())
                return;
            TryRequest(DataUICommand.Select, eventData);
        }

        private bool IsEventSystemFocusInsideRow()
        {
            var eventSystem = EventSystem.current;
            if (eventSystem == null)
                return false;

            var selected = eventSystem.currentSelectedGameObject;
            if (selected == null)
                return false;

            var selectedTransform = selected.transform;
            if (selectedTransform == null)
                return false;

            return selectedTransform.IsChildOf(transform);
        }

        private bool ShouldHandleSelectOnNavigation()
        {
            var ctx = GetComponentInParent<IDataItemContext>();
            if (ctx?.Host is DataTableWidget widget)
                return widget.ShouldSelectOnNavigation();

            return true;
        }
    }
}
