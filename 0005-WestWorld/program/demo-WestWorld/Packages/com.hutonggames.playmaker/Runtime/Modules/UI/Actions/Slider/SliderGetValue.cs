
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
	public sealed class SliderGetValue : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Get Slider Value")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _getValue);
		}
		
		public override void Execute()
		{
			_getValue.Value = _slider.Value.value;
		}
		
		public override string GetSummary()
		{
			return "Get {_slider} value -> {_getValue}";
		}
	}
}
