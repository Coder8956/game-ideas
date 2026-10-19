using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.TMP_InputField)]
    [ActionDescription("Send an Event when the Input Field text selection has ended.")]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-InputField.html")]
    public sealed class TMP_InputFieldOnEndTextSelection : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
        [Tooltip("The InputField")]
        [SerializeField]
        private TMP_InputFieldVar _inputField;

        [Tooltip("The Event to send when the InputField text selection has ended.")]
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
            _inputField.Value.onEndTextSelection.AddListener(DoOnEndTextSelection);
        }
		
        public override void OnStop()
        {
            if (_inputField.Value == null) return;
            _inputField.Value.onEndTextSelection.RemoveListener(DoOnEndTextSelection);
        }
        public void DoOnEndTextSelection(string newValue, int startPosition, int endPosition)
        {
            _selectedText.Value = newValue;
            _startPosition.Value = startPosition;
            _endPosition.Value = endPosition;
            SendEvent(_sendEvent);
        }
		
        public override string GetSummary() => "Send {_sendEvent} when {_inputField} text selection ends " +
                                               "{_selectedText:output} {_startPosition:output} {_endPosition:output}";
    }
}
