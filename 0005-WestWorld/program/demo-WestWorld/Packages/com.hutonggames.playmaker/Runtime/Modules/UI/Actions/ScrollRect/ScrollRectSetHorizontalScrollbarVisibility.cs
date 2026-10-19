
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The mode of visibility for the horizontal scrollbar.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetHorizontalScrollbarVisibility : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Horizontal Scrollbar Visibility")]
		[SerializeField]
		private ScrollRect_ScrollbarVisibilityVar _setHorizontalScrollbarVisibility;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setHorizontalScrollbarVisibility);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.horizontalScrollbarVisibility = _setHorizontalScrollbarVisibility.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} horizontal scrollbar visibility to {_setHorizontalScrollbarVisibility}";
		}
	}
}
