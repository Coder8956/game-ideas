/*
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[PublicAPI]
	[ActionCategory(Category.UGUI_Slider)]
	[ActionDescription("Handling for when the canvas is rebuilt.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Slider.html")]
	public sealed class SliderRebuild : BaseAction
	{
		
		[Tooltip("The Slider.")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.UI.SliderVar _slider;
		
		[Tooltip("Executing.")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.UI.CanvasUpdateVar _executing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_slider, _executing);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Slider.Rebuild(UnityEngine.UI.CanvasUpdate);
			_slider.Value.Rebuild(_executing.Value);
		}
		
		public override string GetSummary()
		{
			return "Rebuild {_slider} {_executing}";
		}
	}
}
*/
