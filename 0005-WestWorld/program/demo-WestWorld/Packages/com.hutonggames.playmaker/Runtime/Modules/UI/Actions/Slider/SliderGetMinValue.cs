
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("The minimum allowed value of the slider.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderGetMinValue : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Get Slider Min Value")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMinValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _getMinValue);
		}
		
		public override void Execute()
		{
			_getMinValue.Value = _slider.Value.minValue;
		}
		
		public override string GetSummary()
		{
			return "Get {_slider} min value -> {_getMinValue}";
		}
	}
}
