/*
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[PublicAPI]
	[ActionCategory(Category.UGUI_Scrollbar)]
	[ActionDescription("Handling for when the canvas is rebuilt.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Scrollbar.html")]
	public sealed class ScrollbarRebuild : BaseAction
	{
		
		[Tooltip("The Scrollbar.")]
		[SerializeField]
		private ScrollbarVar _scrollbar;
		
		[Tooltip("Executing.")]
		[SerializeField]
		private CanvasUpdateVar _executing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_scrollbar, _executing);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Scrollbar.Rebuild(UnityEngine.UI.CanvasUpdate);
			_scrollbar.Value.Rebuild(_executing.Value);
		}
		
		public override string GetSummary()
		{
			return "Rebuild {_scrollbar} {_executing}";
		}
	}
}
*/
