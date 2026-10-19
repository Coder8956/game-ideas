/* Maybe...
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("Rebuilds the scroll rect data after initialization.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectRebuild : BaseAction
	{
		
		[Tooltip("The ScrollRect.")]
		[SerializeField]
		private ScrollRectVar _scrollRect;
		
		[Tooltip("The current step of the rendering CanvasUpdate cycle.")]
		[SerializeField]
		private CanvasUpdateVar _executing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollRect, _executing);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.ScrollRect.Rebuild(UnityEngine.UI.CanvasUpdate);
			_scrollRect.Value.Rebuild(_executing.Value);
		}
		
		public override string GetSummary()
		{
			return "Rebuild {_scrollRect} {_executing}";
		}
	}
}
*/
