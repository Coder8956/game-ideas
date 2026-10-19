
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("Callback executed when the value of the slider is changed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderOnValueChanged__UnityEvent : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Set Slider On Value Changed")]
		[SerializeField]
		private Slider_SliderEventVar _onValueChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _onValueChanged);
		}
		
		public override void Execute()
		{
			_slider.Value.onValueChanged = _onValueChanged.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_slider} on value changed to {_onValueChanged}";
		}
	}
}
