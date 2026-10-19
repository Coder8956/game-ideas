
using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("Sets the direction of this slider, optionally changing the layout as well.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderSetDirection : BaseAction
	{
		
		[Tooltip("The Slider.")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("The direction of the slider.")]
		[SerializeField]
		private Slider_DirectionVar _direction;
		
		[Tooltip("Should the layout be flipped together with the slider direction?")]
		[SerializeField]
		private BoolVar _includeRectLayouts;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _direction, _includeRectLayouts);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Slider.SetDirection(UnityEngine.UI.Slider+Direction, System.Boolean);
			_slider.Value.SetDirection(_direction.Value, _includeRectLayouts.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_slider} direction to {_direction} {_includeRectLayouts}";
		}
	}
}
