
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Remove all cached vertices.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer.Clear.html")]
	public sealed class CanvasRendererClear : BaseAction
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
			//UnityEngine.CanvasRenderer.Clear();
			_canvasRenderer.Value.Clear();
		}
		
		public override string GetSummary()
		{
			return "Clear {_canvasRenderer}";
		}
	}
}
