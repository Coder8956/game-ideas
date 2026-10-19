
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("The Alpha Texture that will be passed to the Shader under the _AlphaTex property." +
		"")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer.SetAlphaTexture.html")]
	public sealed class CanvasRendererSetAlphaTexture : BaseAction
	{
		
		[Tooltip("The CanvasRenderer.")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("The Texture to be passed.")]
		[SerializeField, CanBeNullOrEmpty]
		private TextureVar _texture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer);
		}
		
		public override void Execute()
		{
			//UnityEngine.CanvasRenderer.SetAlphaTexture(UnityEngine.Texture);
			_canvasRenderer.Value.SetAlphaTexture(_texture.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} alpha texture to {_texture}";
		}
	}
}
