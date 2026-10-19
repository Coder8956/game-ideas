
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("Sends an event when the Slider value changes.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderOnValueChanged : BaseAction
	{
		public override UpdateMode DefaultUpdateMode => UpdateMode.OnEventUpdate;
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;

		[Tooltip("The Event to send when the slider value changes.")]
		[SerializeField]
		private EventRef _sendEvent;
		
		[OptionalField]
		[Tooltip("The current Slider Value")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _value;
		
		public override bool CanExecute() => CheckParameters(_slider, _sendEvent);
		
		public override void OnStart()
		{
			if (_slider.Value == null) return;
			_slider.Value.onValueChanged.AddListener(DoOnValueChanged);
		}
		
		public override void OnStop()
		{
			if (_slider.Value == null) return;
			_slider.Value.onValueChanged.RemoveListener(DoOnValueChanged);
		}
		public void DoOnValueChanged(float newValue)
		{
			_value.Value = newValue;
			SendEvent(_sendEvent);
		}
		
		public override string GetSummary() => "On {_slider} value changed {_sendEvent} {_value:output}";
	}
}
