
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("Optional RectTransform to use as a handle for the slider.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderSetHandleRect : BaseAction
	{
		
		[Tooltip("The Slider")]
		[SerializeField]
		private SliderVar _slider;
		
		[Tooltip("Set Slider Handle Rect")]
		[SerializeField, CanBeNullOrEmpty]
		private RectTransformVar _setHandleRect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider);
		}
		
		public override void Execute()
		{
			_slider.Value.handleRect = _setHandleRect.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_slider} handle rect to {_setHandleRect}";
		}
	}
}
