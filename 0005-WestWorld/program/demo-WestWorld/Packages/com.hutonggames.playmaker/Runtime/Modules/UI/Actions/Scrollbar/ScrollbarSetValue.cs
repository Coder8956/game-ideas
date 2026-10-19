
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Scrollbar)]
	[ActionDescription("The current value of the scrollbar, between 0 and 1.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Scrollbar.html")]
	public sealed class ScrollbarSetValue : BaseAction
	{
		
		[Tooltip("The Scrollbar")]
		[SerializeField]
		private ScrollbarVar _scrollbar;
		
		[Tooltip("Set Scrollbar Value")]
		[SerializeField]
		private FloatVar _setValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollbar, _setValue);
		}
		
		public override void Execute()
		{
			_scrollbar.Value.value = _setValue.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollbar} value to {_setValue}";
		}
	}
}
