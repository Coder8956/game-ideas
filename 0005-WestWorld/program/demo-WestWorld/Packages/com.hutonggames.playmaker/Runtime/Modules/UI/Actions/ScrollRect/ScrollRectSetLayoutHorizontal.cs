
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("Called by the layout system.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectSetLayoutHorizontal : BaseAction
	{
		
		[Tooltip("The ScrollRect.")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.ScrollRect.SetLayoutHorizontal();
			_scrollRect.Value.SetLayoutHorizontal();
		}
		
		public override string GetSummary()
		{
			return "Set {_scrollRect} layout horizontal";
		}
	}
}
