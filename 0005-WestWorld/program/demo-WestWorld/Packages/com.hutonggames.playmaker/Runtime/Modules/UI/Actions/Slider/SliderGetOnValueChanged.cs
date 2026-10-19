/*
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("Callback executed when the value of the slider is changed.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderGetOnValueChanged : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Get Slider On Value Changed")]
		[SerializeField]
		[WriteOnly]
		private Slider_SliderEventRef _getOnValueChanged;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _getOnValueChanged);
		}
		
		public override void Execute()
		{
			_getOnValueChanged.Value = _slider.Value.onValueChanged;
		}
		
		public override string GetSummary()
		{
			return "Get {_slider} on value changed -> {_getOnValueChanged}";
		}
	}
}
*/
