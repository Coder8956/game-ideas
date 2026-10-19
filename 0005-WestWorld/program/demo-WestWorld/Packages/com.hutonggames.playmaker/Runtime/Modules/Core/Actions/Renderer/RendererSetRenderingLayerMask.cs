
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Determines which rendering layer this renderer lives on.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-renderingLayerMask.html")]
	public sealed class RendererSetRenderingLayerMask : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Rendering Layer Mask")]
		[SerializeField]
		private UIntVar _setRenderingLayerMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setRenderingLayerMask);
		}
		
		public override void Execute()
		{
			_renderer.Value.renderingLayerMask = _setRenderingLayerMask.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Rendering Layer Mask to {_setRenderingLayerMask}";
		}
	}
}
