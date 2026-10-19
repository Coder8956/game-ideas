
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Determines which rendering layer this renderer lives on.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-renderingLayerMask.html")]
	public sealed class RendererGetRenderingLayerMask : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Rendering Layer Mask")]
		[SerializeField]
		[WriteOnly]
		private UIntRef _getRenderingLayerMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getRenderingLayerMask);
		}
		
		public override void Execute()
		{
			_getRenderingLayerMask.Value = _renderer.Value.renderingLayerMask;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} renderingLayerMask -> {_getRenderingLayerMask}";
		}
	}
}
