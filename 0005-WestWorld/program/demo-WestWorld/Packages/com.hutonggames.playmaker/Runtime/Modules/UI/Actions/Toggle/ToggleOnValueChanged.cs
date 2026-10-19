
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Send an Event when a toggle value changes.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleOnValueChanged : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
		[Tooltip("The Toggle")]
		[SerializeField]
		private ToggleVar _toggle;
		
		[Tooltip("Event to send if the toggle value is true.")] 
		[SerializeField] 
		private EventRef _trueEvent;
		
		[Tooltip("Event to send if the toggle value is false.")] 
		[SerializeField] 
		private EventRef _falseEvent;

		[OptionalField]
		[Tooltip("The new value of the toggle.")] 
		[SerializeField]
		private BoolRef _storeValue;
		
		public override bool CanExecute() => CheckParameters(_toggle, _trueEvent);

		public override void OnStart()
		{
			if (_toggle.Value == null) return;
			_toggle.Value.onValueChanged.AddListener(DoOnValueChanged);
		}
		
		public override void OnStop()
		{
			if (_toggle.Value == null) return;
			_toggle.Value.onValueChanged.RemoveListener(DoOnValueChanged);
		}
		
		private void DoOnValueChanged(bool newValue)
		{
			_storeValue.Value = newValue;
			SendEvent(newValue ? _trueEvent : _falseEvent);
		}

		public override string GetSummary() =>
			"{_toggle} On Value Changed {_trueEvent:True} {_falseEvent:False} {_storeValue:output}";
	}
}
