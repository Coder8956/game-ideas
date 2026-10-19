
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("Should movement inertia be enabled?")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetInertia : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Inertia")]
		[SerializeField]
		private BoolVar _setInertia;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setInertia);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.inertia = _setInertia.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} inertia to {_setInertia}";
		}
	}
}
