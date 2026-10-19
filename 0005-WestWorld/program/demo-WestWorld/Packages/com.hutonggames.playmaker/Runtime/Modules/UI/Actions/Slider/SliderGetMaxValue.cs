
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("The maximum allowed value of the slider.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderGetMaxValue : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Get Slider Max Value")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaxValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _getMaxValue);
		}
		
		public override void Execute()
		{
			_getMaxValue.Value = _slider.Value.maxValue;
		}
		
		public override string GetSummary()
		{
			return "Get {_slider} max value -> {_getMaxValue}";
		}
	}
}
