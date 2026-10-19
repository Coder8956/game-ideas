using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.TMP_InputField)]
    [ActionDescription("Send an Event when the Input Field is deselected.")]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
    public sealed class TMP_InputFieldOnDeselect : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
        [Tooltip("The InputField")]
        [SerializeField]
        private TMP_InputFieldVar _inputField;

        [Tooltip("The Event to send when the InputField is deselected.")]
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
            _inputField.Value.onDeselect.AddListener(DoOnDeselect);
        }
		
        public override void OnStop()
        {
            if (_inputField.Value == null) return;
            _inputField.Value.onDeselect.RemoveListener(DoOnDeselect);
        }
        public void DoOnDeselect(string newValue)
        {
            _value.Value = newValue;
            SendEvent(_sendEvent);
        }
		
        public override string GetSummary() => "Send {_sendEvent} when {_inputField} is deselected {_value:output}";
    }
}
