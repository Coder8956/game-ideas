
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Scrollbar)]
	[ActionDescription("The number of steps to use for the value. A value of 0 disables use of steps.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Scrollbar.html")]
	public sealed class ScrollbarSetNumberOfSteps : BaseAction
	{
		
		[Tooltip("The Scrollbar")]
		[SerializeField]
		private ScrollbarVar _scrollbar;
		
		[Tooltip("Set Scrollbar Number Of Steps")]
		[SerializeField]
		private IntegerVar _setNumberOfSteps;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollbar, _setNumberOfSteps);
		}
		
		public override void Execute()
		{
			_scrollbar.Value.numberOfSteps = _setNumberOfSteps.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollbar} number of steps to {_setNumberOfSteps}";
		}
	}
}
