
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshProUGUI)]
	[ActionDescription("Get the CanvasRenderer used by the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshProUGUI.html")]
	public sealed class TextMeshProUGUIGetCanvasRenderer : BaseAction
	{
		
		[Tooltip("The TextMeshProUGUI")]
		[SerializeField]
		private TextMeshProUGUIVar _textMeshProUGUI;
		
		[Tooltip("Get TextMeshProUGUI Canvas Renderer")]
		[SerializeField]
		[WriteOnly]
		private CanvasRendererRef _getCanvasRenderer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshProUGUI, _getCanvasRenderer);
		}
		
		public override void Execute()
		{
			_getCanvasRenderer.Value = _textMeshProUGUI.Value.canvasRenderer;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshProUGUI} canvas renderer -> {_getCanvasRenderer}";
		}
	}
}
