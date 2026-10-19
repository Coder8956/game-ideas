
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("Should vertical scrolling be enabled?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetVertical : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Vertical")]
		[SerializeField]
		private BoolVar _setVertical;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setVertical);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.vertical = _setVertical.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} vertical to {_setVertical}";
		}
	}
}
