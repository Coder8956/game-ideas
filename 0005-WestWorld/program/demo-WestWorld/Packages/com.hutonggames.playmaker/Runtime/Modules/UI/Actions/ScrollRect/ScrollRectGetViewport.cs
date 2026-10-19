
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("Reference to the viewport RectTransform that is the parent of the content RectTra" +
		"nsform.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectGetViewport : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Get ScrollRect Viewport")]
		[SerializeField]
		[WriteOnly]
		private RectTransformVar _getViewport;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _getViewport);
		}
		
		public override void Execute()
		{
			_getViewport.Value = _scrollRect.Value.viewport;
		}
		
		public override string GetSummary()
		{
			return "Get {_scrollRect} viewport -> {_getViewport}";
		}
	}
}
