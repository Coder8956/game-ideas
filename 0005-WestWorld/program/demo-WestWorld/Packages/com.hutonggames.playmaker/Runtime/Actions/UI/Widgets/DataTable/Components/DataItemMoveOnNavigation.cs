using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Sends DataUI move commands from EventSystem directional navigation.
    /// Attach to a row object that participates in UI selection navigation.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Data Item Move On Navigation")]
    [Icon(Strings.EditorIconsPath + "DataRowSelectionIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-item-selection/")]
    public sealed class DataItemMoveOnNavigation : DataItemActionBase, IMoveHandler
    {
        [SerializeField, Tooltip("Handle Up navigation by sending MoveUp.")]
        private bool _handleUp = true;

        [SerializeField, Tooltip("Handle Down navigation by sending MoveDown.")]
        private bool _handleDown = true;

        [SerializeField, Tooltip("If enabled, marks the move event as used after a handled move.")]
        private bool _consumeHandledMove = true;

        [SerializeField, Tooltip("If enabled, Up/Down input is also consumed when move cannot be performed (at bounds). " +
                                 "Prevents EventSystem navigation from leaving the table.")]
        private bool _consumeAtBounds = true;

        public void OnMove(AxisEventData eventData)
        {
            if (eventData == null)
                return;
            if (!ShouldHandleMoveOnNavigation())
                return;

            switch (eventData.moveDir)
            {
                case MoveDirection.Up:
                    if (_handleUp)
                    {
                        bool moved = TryRequest(DataUICommand.MoveUp, eventData);
                        if ((moved && _consumeHandledMove) || (!moved && _consumeAtBounds))
                            eventData.Use();
                    }
                    return;

                case MoveDirection.Down:
                    if (_handleDown)
                    {
                        bool moved = TryRequest(DataUICommand.MoveDown, eventData);
                        if ((moved && _consumeHandledMove) || (!moved && _consumeAtBounds))
                            eventData.Use();
                    }
                    return;
            }
        }

        private bool ShouldHandleMoveOnNavigation()
        {
            var ctx = GetComponentInParent<IDataItemContext>();
            if (ctx?.Host is DataTableWidget widget)
                return widget.ShouldMoveOnNavigation();

            return true;
        }
    }
}
