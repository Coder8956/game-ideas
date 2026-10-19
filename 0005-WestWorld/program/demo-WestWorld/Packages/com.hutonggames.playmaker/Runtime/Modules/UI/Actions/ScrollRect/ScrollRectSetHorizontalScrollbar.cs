
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("Optional Scrollbar object linked to the horizontal scrolling of the ScrollRect.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetHorizontalScrollbar : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Horizontal Scrollbar")]
		[SerializeField, CanBeNullOrEmpty]
		private ScrollbarVar _setHorizontalScrollbar;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.horizontalScrollbar = _setHorizontalScrollbar.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} horizontal scrollbar to {_setHorizontalScrollbar}";
		}
	}
}
