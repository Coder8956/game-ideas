
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("Optional Scrollbar object linked to the vertical scrolling of the ScrollRect.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetVerticalScrollbar : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Vertical Scrollbar")]
		[SerializeField, CanBeNullOrEmpty]
		private ScrollbarVar _setVerticalScrollbar;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.verticalScrollbar = _setVerticalScrollbar.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} vertical scrollbar to {_setVerticalScrollbar}";
		}
	}
}
