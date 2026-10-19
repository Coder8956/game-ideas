
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The horizontal scroll position as a value between 0 and 1, with 0 being at the left.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectGetHorizontalNormalizedPosition : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Get ScrollRect Horizontal Normalized Position")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getHorizontalNormalizedPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _getHorizontalNormalizedPosition);
		}
		
		public override void Execute()
		{
			_getHorizontalNormalizedPosition.Value = _scrollRect.Value.horizontalNormalizedPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_scrollRect} horizontal normalized position -> {_getHorizontalNormalizedPosition}";
		}
	}
}
