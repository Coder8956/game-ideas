
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("Should horizontal scrolling be enabled?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetHorizontal : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Horizontal")]
		[SerializeField]
		private BoolVar _setHorizontal;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setHorizontal);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.horizontal = _setHorizontal.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} horizontal to {_setHorizontal}";
		}
	}
}
