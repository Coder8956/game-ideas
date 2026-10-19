
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
	public sealed class ScrollRectSetVerticalNormalizedPosition : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Vertical Normalized Position")]
		[SerializeField]
		private FloatVar _setVerticalNormalizedPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setVerticalNormalizedPosition);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.verticalNormalizedPosition = _setVerticalNormalizedPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} vertical normalized position to {_setVerticalNormalizedPosition}";
		}
	}
}
