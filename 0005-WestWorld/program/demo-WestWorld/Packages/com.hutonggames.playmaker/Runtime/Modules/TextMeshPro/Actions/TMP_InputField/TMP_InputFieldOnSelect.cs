using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.TMP_InputField)]
    [ActionDescription("Send an Event when the Input Field is selected.")]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
    public sealed class TMP_InputFieldOnSelect : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
        [Tooltip("The InputField")]
        [SerializeField]
        private TMP_InputFieldVar _inputField;

        [Tooltip("The Event to send when the InputField is selected.")]
        [SerializeField]
        private EventRef _sendEvent;
		
        [OptionalField]
        [Tooltip("The InputField Value")]
        [SerializeField]
        [WriteOnly]
        private StringRef _value;
		
        public override bool CanExecute() => CheckParameters(_inputField, _sendEvent);
		
        public override void OnStart()
        {
            if (_inputField.Value == null) return;
            _inputField.Value.onSelect.AddListener(DoOnSelect);
        }
		
        public override void OnStop()
        {
            if (_inputField.Value == null) return;
            _inputField.Value.onSelect.RemoveListener(DoOnSelect);
        }
        public void DoOnSelect(string newValue)
        {
            _value.Value = newValue;
            SendEvent(_sendEvent);
        }
		
        public override string GetSummary() => "Send {_sendEvent} when {_inputField} is selected {_value:output}";
    }
}
