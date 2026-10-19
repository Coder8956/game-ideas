using HutongGames.PlayMaker.Actions;
using HutongGames.PlayMaker.UGUIEvents;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Tap/click requests a single action (Select/ToggleSelect/Delete/Custom/etc).
    /// Also forwards OnPointerClick system event to the item GameObject.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Data Item Click Action")]
    [Icon(Strings.EditorIconsPath + "DataRowSelectionIcon.png")]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-item-click-action/")]
    public sealed class DataItemClickAction : DataItemActionBase, IPointerClickHandler
    {
        public enum TapTrigger
        {
            AnyClickOrTap,
            PrimaryOnly,   // tap / left click
            SecondaryOnly  // right click (desktop)
        }

        [FormerlySerializedAs("_action")]
        [SerializeField, Tooltip("Action to request when tapped/clicked.")]
        private DataUICommand _command = DataUICommand.Select;

        [SerializeField, Tooltip("Which tap/click type should trigger the action. Touch taps count as Primary.")]
        private TapTrigger _tapTrigger = TapTrigger.PrimaryOnly;

        [Tooltip("Only trigger when this GameObject is the direct UI raycast hit." +
                 "\n\nWhen enabled, this action will NOT fire if another UI element is on top of this one" +
                 "\n(e.g. buttons, overlays, icons, or other graphics)." +
                 "\n\nDisable this if you want clicks anywhere over this hierarchy to trigger the action.")]
        [SerializeField]
        private bool _requireDirectHit = true;

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData == null)
                return;

            if (!TapMatchesTrigger(eventData, _tapTrigger))
                return;

            if (_requireDirectHit && !IsDirectHit(eventData))
                return;

            TryRequest(command: _command, payload: eventData);
            SendItemSystemEvent(OnPointerClickEvent.Get(eventData));
        }

        private static bool TapMatchesTrigger(PointerEventData eventData, TapTrigger trigger)
        {
            return trigger switch
            {
                TapTrigger.AnyClickOrTap => true,
                TapTrigger.PrimaryOnly => eventData.button == PointerEventData.InputButton.Left,
                TapTrigger.SecondaryOnly => eventData.button == PointerEventData.InputButton.Right,
                _ => true
            };
        }
    }
}
