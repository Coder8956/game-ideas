
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The rate at which movement slows down.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetDecelerationRate : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Deceleration Rate")]
		[SerializeField]
		private FloatVar _setDecelerationRate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setDecelerationRate);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.decelerationRate = _setDecelerationRate.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} deceleration rate to {_setDecelerationRate}";
		}
	}
}
