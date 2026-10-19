using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.UGUI_InputField)]
    [ActionDescription("Send Event when the InputField value changes.")]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
    public sealed class InputFieldOnChanged : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
        [Tooltip("The InputField")]
        [SerializeField]
        private InputFieldVar _inputField;

        [Tooltip("The Event to send when the InputField value changes.")]
        [SerializeField]
        private EventRef _sendEvent;
		
        [OptionalField]
        [Tooltip("The current InputField Value")]
        [SerializeField]
        [WriteOnly]
        private StringRef _value;
		
        public override bool CanExecute() => CheckParameters(_inputField, _sendEvent);
		
        public override void OnStart()
        {
            if (_inputField.Value == null) return;
            _inputField.Value.onValueChanged.AddListener(DoOnValueChanged);
        }
		
        public override void OnStop()
        {
            if (_inputField.Value == null) return;
            _inputField.Value.onValueChanged.RemoveListener(DoOnValueChanged);
        }
        public void DoOnValueChanged(string newValue)
        {
            _value.Value = newValue;
            SendEvent(_sendEvent);
        }
		
        public override string GetSummary() => "On {_inputField} value changed {_sendEvent} {_value:output}";
    }
}
