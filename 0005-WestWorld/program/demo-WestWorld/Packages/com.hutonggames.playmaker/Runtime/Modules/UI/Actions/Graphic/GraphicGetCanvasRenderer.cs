
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.UGUI_Graphic)]
	[ActionDescription("The CanvasRenderer used by this Graphic.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.UI.Graphic.html")]
	public sealed class GraphicGetCanvasRenderer : BaseAction
	{
		
		[Tooltip("The Graphic")]
		[SerializeField]
		private GraphicVar _graphic;
		
		[Tooltip("Get Graphic Canvas Renderer")]
		[SerializeField]
		[WriteOnly]
		private CanvasRendererVar _getCanvasRenderer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_graphic, _getCanvasRenderer);
		}
		
		public override void Execute()
		{
			_getCanvasRenderer.Value = _graphic.Value.canvasRenderer;
		}
		
		public override string GetSummary()
		{
			return "Get {_graphic} canvas renderer -> {_getCanvasRenderer}";
		}
	}
}
