/*
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("Sets Value Without Notify on Slider.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderSetValueWithoutNotify : BaseAction
	{
		
		[Tooltip("The Slider.")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Input.")]
		[SerializeField]
		private FloatVar _input;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _input);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Slider.SetValueWithoutNotify(System.Single);
			_slider.Value.SetValueWithoutNotify(_input.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_slider} value without notify to {_input}";
		}
	}
}
*/
