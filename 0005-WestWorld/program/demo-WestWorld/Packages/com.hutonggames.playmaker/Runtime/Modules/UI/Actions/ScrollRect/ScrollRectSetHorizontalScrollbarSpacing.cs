
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The space between the scrollbar and the viewport.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetHorizontalScrollbarSpacing : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Horizontal Scrollbar Spacing")]
		[SerializeField]
		private FloatVar _setHorizontalScrollbarSpacing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setHorizontalScrollbarSpacing);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.horizontalScrollbarSpacing = _setHorizontalScrollbarSpacing.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} horizontal scrollbar spacing to {_setHorizontalScrollbarSpacing}";
		}
	}
}
