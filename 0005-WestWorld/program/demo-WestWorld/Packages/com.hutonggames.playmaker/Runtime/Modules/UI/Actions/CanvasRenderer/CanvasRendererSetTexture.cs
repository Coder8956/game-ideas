
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Sets the texture used by this renderer\'s material.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer.SetTexture.html")]
	public sealed class CanvasRendererSetTexture : BaseAction
	{
		
		[Tooltip("The CanvasRenderer.")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Texture.")]
		[SerializeField, CanBeNullOrEmpty]
		private TextureVar _texture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer);
		}
		
		public override void Execute()
		{
			//UnityEngine.CanvasRenderer.SetTexture(UnityEngine.Texture);
			_canvasRenderer.Value.SetTexture(_texture.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} texture to {_texture}";
		}
	}
}
