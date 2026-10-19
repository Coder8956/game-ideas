
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Set the color of the renderer. Will be multiplied with the UIVertex color and the" +
		" Canvas color.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer.SetColor.html")]
	public sealed class CanvasRendererSetColor : BaseAction
	{
		
		[Tooltip("The CanvasRenderer.")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Renderer multiply color.")]
		[SerializeField]
		private ColorVar _color;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _color);
		}
		
		public override void Execute()
		{
			//UnityEngine.CanvasRenderer.SetColor(UnityEngine.Color);
			_canvasRenderer.Value.SetColor(_color.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} color to {_color}";
		}
	}
}
