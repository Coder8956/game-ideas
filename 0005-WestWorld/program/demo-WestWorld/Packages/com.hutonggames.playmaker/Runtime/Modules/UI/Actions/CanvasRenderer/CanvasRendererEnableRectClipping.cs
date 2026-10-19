
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Enables rect clipping on the CanvasRendered. Geometry outside of the specified re" +
		"ct will be clipped (not rendered).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer.EnableRectClipping.html")]
	public sealed class CanvasRendererEnableRectClipping : BaseAction
	{
		
		[Tooltip("The CanvasRenderer.")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Rect.")]
		[SerializeField]
		private RectVar _rect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _rect);
		}
		
		public override void Execute()
		{
			//UnityEngine.CanvasRenderer.EnableRectClipping(UnityEngine.Rect);
			_canvasRenderer.Value.EnableRectClipping(_rect.Value);
		}
		
		public override string GetSummary()
		{
			return "Enable {_canvasRenderer} rect clipping {_rect}";
		}
	}
}
