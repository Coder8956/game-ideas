using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.TMP_InputField)]
    [ActionDescription("Send an Event when text is selected in the Input Field.")]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
    public sealed class TMP_InputFieldOnTextSelection : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
        [Tooltip("The InputField")]
        [SerializeField]
        private TMP_InputFieldVar _inputField;

        [Tooltip("The Event to send when text is selected in the Input Field.")]
        [SerializeField]
        private EventRef _sendEvent;
		
        [OptionalField]
        [Tooltip("The selected text.")]
        [SerializeField]
        [WriteOnly]
        private StringRef _selectedText;
        
        [OptionalField]
        [Tooltip("Start position of the selection.")]
        [SerializeField]
        [WriteOnly]
        private IntegerRef _startPosition;
        
        [OptionalField]
        [Tooltip("End position of the selection.")]
        [SerializeField]
        [WriteOnly]
        private IntegerRef _endPosition;
		
        public override bool CanExecute() => CheckParameters(_inputField, _sendEvent);
		
        public override void OnStart()
        {
            if (_inputField.Value == null) return;
            _inputField.Value.onTextSelection.AddListener(DoOnTextSelection);
        }
		
        public override void OnStop()
        {
            if (_inputField.Value == null) return;
            _inputField.Value.onTextSelection.RemoveListener(DoOnTextSelection);
        }
        public void DoOnTextSelection(string newValue, int startPosition, int endPosition)
        {
            _selectedText.Value = newValue;
            _startPosition.Value = startPosition;
            _endPosition.Value = endPosition;
            SendEvent(_sendEvent);
        }
		
        public override string GetSummary() => "Send {_sendEvent} when {_inputField} text is selected " +
                                               "{_selectedText:output} {_startPosition:output} {_endPosition:output}";
    }
}
