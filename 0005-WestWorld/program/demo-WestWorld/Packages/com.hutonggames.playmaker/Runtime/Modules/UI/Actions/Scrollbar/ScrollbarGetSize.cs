
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Scrollbar)]
	[ActionDescription("The size of the scrollbar handle where 1 means it fills the entire scrollbar.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Scrollbar.html")]
	public sealed class ScrollbarGetSize : BaseAction
	{
		
		[Tooltip("The Scrollbar")]
		[SerializeField]
		private ScrollbarVar _scrollbar;
		
		[Tooltip("Get Scrollbar Size")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollbar, _getSize);
		}
		
		public override void Execute()
		{
			_getSize.Value = _scrollbar.Value.size;
		}
		
		public override string GetSummary()
		{
			return "Get {_scrollbar} size -> {_getSize}";
		}
	}
}
