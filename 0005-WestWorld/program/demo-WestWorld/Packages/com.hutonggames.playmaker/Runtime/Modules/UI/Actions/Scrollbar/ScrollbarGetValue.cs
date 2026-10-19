
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Scrollbar)]
	[ActionDescription("The current value of the scrollbar, between 0 and 1.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Scrollbar.html")]
	public sealed class ScrollbarGetValue : BaseAction
	{
		
		[Tooltip("The Scrollbar")]
		[SerializeField]
		private ScrollbarVar _scrollbar;
		
		[Tooltip("Get Scrollbar Value")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getValue;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollbar, _getValue);
		}
		
		public override void Execute()
		{
			_getValue.Value = _scrollbar.Value.value;
		}
		
		public override string GetSummary()
		{
			return "Get {_scrollbar} value -> {_getValue}";
		}
	}
}
