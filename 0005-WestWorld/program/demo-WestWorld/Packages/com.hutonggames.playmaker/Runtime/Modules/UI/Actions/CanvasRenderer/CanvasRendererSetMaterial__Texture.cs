
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.UI
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.CanvasRenderer)]
	[ActionDescription("Set the material for the canvas renderer and override the material's \'MainTex\'.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/CanvasRenderer.SetMaterial.html")]
	public sealed class CanvasRendererSetMaterial__Texture : BaseAction
	{
		
		[Tooltip("The CanvasRenderer.")]
		[SerializeField]
		private CanvasRendererVar _canvasRenderer;
		
		[Tooltip("Material for rendering.")]
		[SerializeField]
		private MaterialVar _material;
		
		[Tooltip("Material texture override.")]
		[SerializeField]
		private TextureVar _texture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_canvasRenderer, _material);
		}
		
		public override void Execute()
		{
			_canvasRenderer.Value.SetMaterial(_material.Value, _texture.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_canvasRenderer} material {_material} texture to {_texture}";
		}
	}
}
