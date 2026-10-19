using JetBrains.Annotations;
using TMPro;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.TMP_InputField)]
    [ActionDescription("Send an Event when the touch screen keyboard status changes.")]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
    public sealed class TMP_InputFieldOnTouchScreenKeyboardStatusChanged : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
        [Tooltip("The InputField")]
        [SerializeField]
        private TMP_InputFieldVar _inputField;

        [Tooltip("The Event to send when the touch screen keyboard status changes.")]
        [SerializeField]
        private EventRef _sendEvent;
		
        [OptionalField]
        [Tooltip("The InputField Value")]
        [SerializeField]
        [WriteOnly]
        private TouchScreenKeyboard_StatusRef _value;
		
        public override bool CanExecute() => CheckParameters(_inputField, _sendEvent);
		
        public override void OnStart()
        {
            if (_inputField.Value == null) return;
            _inputField.Value.onTouchScreenKeyboardStatusChanged.AddListener(DoOnStatusChanged);
        }
		
        public override void OnStop()
        {
            if (_inputField.Value == null) return;
            _inputField.Value.onTouchScreenKeyboardStatusChanged.RemoveListener(DoOnStatusChanged);
        }
        public void DoOnStatusChanged(TouchScreenKeyboard.Status status)
        {
            _value.Value = status;
            SendEvent(_sendEvent);
        }
		
        public override string GetSummary() => "{_inputField} On Touch Screen Keyboard Status Changed {_sendEvent} {_value:output}";
    }
}