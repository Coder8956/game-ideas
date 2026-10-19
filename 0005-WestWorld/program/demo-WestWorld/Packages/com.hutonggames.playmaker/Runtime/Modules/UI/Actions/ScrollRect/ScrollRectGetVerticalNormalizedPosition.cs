
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The vertical scroll position as a value between 0 and 1, with 0 being at the bott" +
		"om.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectGetVerticalNormalizedPosition : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Get ScrollRect Vertical Normalized Position")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getVerticalNormalizedPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _getVerticalNormalizedPosition);
		}
		
		public override void Execute()
		{
			_getVerticalNormalizedPosition.Value = _scrollRect.Value.verticalNormalizedPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_scrollRect} vertical normalized position -> {_getVerticalNormalizedPosition}";
		}
	}
}
