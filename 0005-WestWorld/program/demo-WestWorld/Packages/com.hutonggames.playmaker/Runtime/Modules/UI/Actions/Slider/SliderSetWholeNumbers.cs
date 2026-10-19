
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("Should the value only be allowed to be whole numbers?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderSetWholeNumbers : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Set Slider Whole Numbers")]
		[SerializeField]
		private BoolVar _setWholeNumbers;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _setWholeNumbers);
		}
		
		public override void Execute()
		{
			_slider.Value.wholeNumbers = _setWholeNumbers.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_slider} whole numbers to {_setWholeNumbers}";
		}
	}
}
