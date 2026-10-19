
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The sensitivity to scroll wheel and track pad scroll events.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetScrollSensitivity : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Scroll Sensitivity")]
		[SerializeField]
		private FloatVar _setScrollSensitivity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setScrollSensitivity);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.scrollSensitivity = _setScrollSensitivity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} scroll sensitivity to {_setScrollSensitivity}";
		}
	}
}
