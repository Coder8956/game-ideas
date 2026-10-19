
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
	public sealed class ScrollRectGetNormalizedPosition : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Get ScrollRect Normalized Position")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getNormalizedPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _getNormalizedPosition);
		}
		
		public override void Execute()
		{
			_getNormalizedPosition.Value = _scrollRect.Value.normalizedPosition;
		}
		
		public override string GetSummary()
		{
			return "Get {_scrollRect} normalized position -> {_getNormalizedPosition}";
		}
	}
}
