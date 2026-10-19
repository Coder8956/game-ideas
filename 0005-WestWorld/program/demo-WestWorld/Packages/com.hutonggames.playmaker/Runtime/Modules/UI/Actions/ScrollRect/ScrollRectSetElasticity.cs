
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The amount of elasticity to use when the content moves beyond the scroll rect.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetElasticity : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Elasticity")]
		[SerializeField]
		private FloatVar _setElasticity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setElasticity);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.elasticity = _setElasticity.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} elasticity to {_setElasticity}";
		}
	}
}
