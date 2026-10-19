using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.UGUI_Dropdown)]
    [ActionDescription("Send an Event when a Dropdown value changes.")]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Dropdown.html")]
    public sealed class DropdownOnValueChanged : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
        [Tooltip("The Toggle")]
        [SerializeField]
        private DropdownVar _dropdown;

        [Tooltip("The Event to send when the Scrollbar value changes.")]
        [SerializeField]
        private EventRef _sendEvent;
        
        [OptionalField]
        [Tooltip("The new value of the Dropdown.")] 
        [SerializeField]
        private IntegerRef _storeValue;
		
        public override bool CanExecute() => CheckParameters(_dropdown, _sendEvent);

        public override void OnStart()
        {
            if (_dropdown.Value == null) return;
            _dropdown.Value.onValueChanged.AddListener(DoOnValueChanged);
        }
		
        public override void OnStop()
        {
            if (_dropdown.Value == null) return;
            _dropdown.Value.onValueChanged.RemoveListener(DoOnValueChanged);
        }
		
        private void DoOnValueChanged(int newValue)
        {
            _storeValue.Value = newValue;
            SendEvent(_sendEvent);
        }

        public override string GetSummary() => "On {_dropdown} value changed {_sendEvent} {_storeValue:output}";
    }
}
