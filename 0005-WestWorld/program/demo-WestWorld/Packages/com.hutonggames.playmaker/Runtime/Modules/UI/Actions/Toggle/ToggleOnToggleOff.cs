
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Send an Event when a toggle value changes to false.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleOnToggleOff : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
		[Tooltip("The Toggle")]
		[SerializeField]
		private ToggleVar _toggle;
		
		[Tooltip("Send an Event when a toggle value changes to false.")] 
		[SerializeField] 
		private EventRef _sendEvent;
		
		public override bool CanExecute() => CheckParameters(_toggle, _sendEvent);

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
			if (!newValue)
			{
				SendEvent(_sendEvent);
			}
		}
		
		public override string GetSummary() => "On {_toggle} off {_sendEvent}";
	}
}
