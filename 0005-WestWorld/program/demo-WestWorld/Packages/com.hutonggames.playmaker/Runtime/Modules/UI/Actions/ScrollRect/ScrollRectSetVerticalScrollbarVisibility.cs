
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The mode of visibility for the vertical scrollbar.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetVerticalScrollbarVisibility : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Vertical Scrollbar Visibility")]
		[SerializeField]
		private ScrollRect_ScrollbarVisibilityVar _setVerticalScrollbarVisibility;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setVerticalScrollbarVisibility);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.verticalScrollbarVisibility = _setVerticalScrollbarVisibility.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} vertical scrollbar visibility to {_setVerticalScrollbarVisibility}";
		}
	}
}
