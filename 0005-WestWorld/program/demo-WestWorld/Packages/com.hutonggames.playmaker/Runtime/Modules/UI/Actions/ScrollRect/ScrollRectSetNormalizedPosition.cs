
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The scroll position as a Vector2 between (0,0) and (1,1) with (0,0) being the low" +
		"er left corner.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetNormalizedPosition : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Normalized Position")]
		[SerializeField]
		private Vector2Var _setNormalizedPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _setNormalizedPosition);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.normalizedPosition = _setNormalizedPosition.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} normalized position to {_setNormalizedPosition}";
		}
	}
}
