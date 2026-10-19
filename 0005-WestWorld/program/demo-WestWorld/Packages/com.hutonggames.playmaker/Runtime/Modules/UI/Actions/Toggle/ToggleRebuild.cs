/*
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[PublicAPI]
	[ActionCategory(Category.UGUI_Toggle)]
	[ActionDescription("Handling for when the canvas is rebuilt.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/script-Toggle.html")]
	public sealed class ToggleRebuild : BaseAction
	{
		
		[Tooltip("The Toggle.")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.UI.ToggleVar _toggle;
		
		[Tooltip("Executing.")]
		[SerializeField]
		private HutongGames.PlayMaker.Actions.UI.CanvasUpdateVar _executing;
		
		public override bool CanExecute()
		{
			return CheckParameters(_toggle, _executing);
		}
		
		public override void Execute()
		{
			//UnityEngine.UI.Toggle.Rebuild(UnityEngine.UI.CanvasUpdate);
			_toggle.Value.Rebuild(_executing.Value);
		}
		
		public override string GetSummary()
		{
			return "Rebuild {_toggle} {_executing}";
		}
	}
}
*/
