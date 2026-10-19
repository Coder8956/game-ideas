
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
	public sealed class SliderSetMinValue : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Set Slider Min Value")]
		[SerializeField]
		private FloatVar _setMinValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _setMinValue);
		}
		
		public override void Execute()
		{
			_slider.Value.minValue = _setMinValue.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_slider} min value to {_setMinValue}";
		}
	}
}
