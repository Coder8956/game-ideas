
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
	public sealed class SliderSetMaxValue : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Set Slider Max Value")]
		[SerializeField]
		private FloatVar _setMaxValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _setMaxValue);
		}
		
		public override void Execute()
		{
			_slider.Value.maxValue = _setMaxValue.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_slider} max value to {_setMaxValue}";
		}
	}
}
