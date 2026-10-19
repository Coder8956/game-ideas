
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("The content that can be scrolled. It should be a child of the GameObject with Scr" +
		"ollRect on it.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetContent : BaseAction
	{
		
		[Tooltip("The ScrollRect")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("Set ScrollRect Content")]
		[SerializeField, CanBeNullOrEmpty]
		private RectTransformVar _setContent;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect);
		}
		
		public override void Execute()
		{
			_scrollRect.Value.content = _setContent.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} content to {_setContent}";
		}
	}
}
