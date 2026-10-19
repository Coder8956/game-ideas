
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Disables rectangle clipping for this CanvasRenderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer.DisableRectClipping.html")]
	public sealed class CanvasRendererDisableRectClipping : BaseAction
	{
		
		[Tooltip("The CanvasRenderer.")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer);
		}
		
		public override void Execute()
		{
			//UnityEngine.CanvasRenderer.DisableRectClipping();
			_canvasRenderer.Value.DisableRectClipping();
		}
		
		public override string GetSummary()
		{
			return "Disable {_canvasRenderer} rect clipping";
		}
	}
}
