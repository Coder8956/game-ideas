
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("The current value of the slider.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderSetValue : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Set Slider Value")]
		[SerializeField]
		private FloatVar _setValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _setValue);
		}
		
		public override void Execute()
		{
			_slider.Value.value = _setValue.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_slider} value to {_setValue}";
		}
	}
}
