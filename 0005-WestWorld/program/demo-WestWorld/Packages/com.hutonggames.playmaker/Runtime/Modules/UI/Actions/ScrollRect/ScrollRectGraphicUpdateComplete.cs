/* Maybe...
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("See ICanvasElement.GraphicUpdateComplete.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectGraphicUpdateComplete : BaseAction
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
			//UnityEngine.UI.ScrollRect.GraphicUpdateComplete();
			_scrollRect.Value.GraphicUpdateComplete();
		}
		
		public override string GetSummary()
		{
			return "Complete {_scrollRect} graphic update";
		}
	}
}
*/
