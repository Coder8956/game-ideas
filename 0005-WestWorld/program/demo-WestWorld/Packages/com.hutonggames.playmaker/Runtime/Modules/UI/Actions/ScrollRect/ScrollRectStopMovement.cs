
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_ScrollRect)]
	[ActionDescription("Sets the velocity to zero on both axes so the content stops moving.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-ScrollRect.html")]
	public sealed class ScrollRectStopMovement : BaseAction
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
			//UnityEngine.UI.ScrollRect.StopMovement();
			_scrollRect.Value.StopMovement();
		}
		
		public override string GetSummary()
		{
			return "Stop {_scrollRect} movement";
		}
	}
}
