using HutongGames.PlayMaker.UGUIEvents;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.UI
{
    /// <summary>
    /// Attach to any uGUI Button to request an action from the parent widget without UnityEvent wiring.
    /// Also forwards OnPointerClick system event to the item GameObject.
    /// </summary>
    [AddComponentMenu("PlayMaker/Widgets/Data Item Button Action")]
    [RequireComponent(typeof(Button))]
    [HelpURL("https://hutonggames.com/playmaker/docs/guides/ui-widgets/data/data-item-button-action/")]
    public sealed class DataItemButtonAction : DataItemActionBase
    {
        [FormerlySerializedAs("_action")]
        [SerializeField, Tooltip("Action to request from the parent widget when clicked.")]
        private DataUICommand _command = DataUICommand.Delete;

        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            if (_button != null)
                _button.onClick.AddListener(OnClicked);
        }

        private void OnDisable()
        {
            if (_button != null)
                _button.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked()
        {
            TryRequest(command: _command);

            // Button.onClick does not provide PointerEventData, so this forwards with null event data.
            SendItemSystemEvent(OnPointerClickEvent.Get(null));
        }
    }
}
