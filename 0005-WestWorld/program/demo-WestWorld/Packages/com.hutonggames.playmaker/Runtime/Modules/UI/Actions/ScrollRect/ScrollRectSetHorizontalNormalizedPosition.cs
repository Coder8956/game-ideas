
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The horizontal scroll position as a value between 0 and 1, with 0 being at the le" +
		"ft.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetHorizontalNormalizedPosition : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Horizontal Normalized Position")]
		[SerializeField]
		private FloatVar _setHorizontalNormalizedPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setHorizontalNormalizedPosition);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.horizontalNormalizedPosition = _setHorizontalNormalizedPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} horizontal normalized position to {_setHorizontalNormalizedPosition}";
		}
	}
}
