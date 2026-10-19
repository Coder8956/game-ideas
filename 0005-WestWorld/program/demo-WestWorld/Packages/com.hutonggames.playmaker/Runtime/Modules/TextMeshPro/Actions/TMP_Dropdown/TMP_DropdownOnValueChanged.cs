using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
    [System.Serializable]
    [PublicAPI]
    [ActionCategory(Category.TMP_Dropdown)]
    [ActionDescription("Send an Event when a Dropdown value changes.")]
    [HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TMP_Dropdown.html")]
    public sealed class TMP_DropdownOnValueChanged : BaseAction
    {
        public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
        [Tooltip("The Toggle")]
        [SerializeField]
        private TMP_DropdownVar _dropdown;

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

        public override string GetSummary() => "{_dropdown} On Value Changed {_sendEvent} {_storeValue:output}";
    }
}