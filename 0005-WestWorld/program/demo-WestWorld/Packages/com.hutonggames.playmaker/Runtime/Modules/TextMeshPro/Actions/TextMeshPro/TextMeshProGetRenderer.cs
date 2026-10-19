
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TextMeshPro)]
	[ActionDescription("Returns the rendered assigned to the text object.")]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.textmeshpro@4.0/api/TMPro.TextMeshPro.html")]
	public sealed class TextMeshProGetRenderer : BaseAction
	{
		
		[Tooltip("The TextMeshPro")]
		[SerializeField]
		private TextMeshProVar _textMeshPro;
		
		[Tooltip("Get TextMeshPro Renderer")]
		[SerializeField]
		[WriteOnly]
		private RendererVar _getRenderer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_textMeshPro, _getRenderer);
		}
		
		public override void Execute()
		{
			_getRenderer.Value = _textMeshPro.Value.renderer;
		}
		
		public override string GetSummary()
		{
			return "Get {_textMeshPro} renderer -> {_getRenderer}";
		}
	}
}
