
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Scrollbar)]
	[ActionDescription("Sends an event when the Scrollbar value changes.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Scrollbar.html")]
	public sealed class ScrollbarOnValueChanged : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
		[Tooltip("The Scrollbar")]
		[SerializeField]
		private ScrollbarVar _scrollbar;

		[Tooltip("The Event to send when the Scrollbar value changes.")]
		[SerializeField]
		private EventRef _sendEvent;
		
		[OptionalField]
		[Tooltip("The current Scrollbar Value")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _value;
		
		public override bool CanExecute() => CheckParameters(_scrollbar, _sendEvent);
		
		public override void OnStart()
		{
			if (_scrollbar.Value == null) return;
			_scrollbar.Value.onValueChanged.AddListener(DoOnValueChanged);
		}
		
		public override void OnStop()
		{
			if (_scrollbar.Value == null) return;
			_scrollbar.Value.onValueChanged.RemoveListener(DoOnValueChanged);
		}
		public void DoOnValueChanged(float newValue)
		{
			_value.Value = newValue;
			SendEvent(_sendEvent);
		}
		
		public override string GetSummary() => "On {_scrollbar} value changed {_sendEvent} {_value:output}";
	}
}
