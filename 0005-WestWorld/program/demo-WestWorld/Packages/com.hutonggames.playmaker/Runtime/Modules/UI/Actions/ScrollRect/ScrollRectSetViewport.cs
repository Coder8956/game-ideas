
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
	public sealed class ScrollRectSetViewport : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Viewport")]
		[SerializeField, CanBeNullOrEmpty]
		private RectTransformVar _setViewport;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.viewport = _setViewport.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} viewport to {_setViewport}";
		}
	}
}
