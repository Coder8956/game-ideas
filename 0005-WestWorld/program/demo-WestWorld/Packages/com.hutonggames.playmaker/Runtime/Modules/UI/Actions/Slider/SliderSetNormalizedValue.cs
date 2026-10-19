
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
	public sealed class SliderSetNormalizedValue : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Set Slider Normalized Value")]
		[SerializeField]
		private FloatVar _setNormalizedValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _setNormalizedValue);
		}
		
		public override void Execute()
		{
			_slider.Value.normalizedValue = _setNormalizedValue.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_slider} normalized value to {_setNormalizedValue}";
		}
	}
}
