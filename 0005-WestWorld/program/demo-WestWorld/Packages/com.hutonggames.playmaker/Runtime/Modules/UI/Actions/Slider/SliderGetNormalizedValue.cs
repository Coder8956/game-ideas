
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("The current value of the slider normalized into a value between 0 and 1.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderGetNormalizedValue : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Get Slider Normalized Value")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getNormalizedValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _getNormalizedValue);
		}
		
		public override void Execute()
		{
			_getNormalizedValue.Value = _slider.Value.normalizedValue;
		}
		
		public override string GetSummary()
		{
			return "Get {_slider} normalized value -> {_getNormalizedValue}";
		}
	}
}
