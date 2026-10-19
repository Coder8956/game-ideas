
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Allows turning off rendering for a specific component.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-forceRenderingOff.html")]
	public sealed class RendererGetForceRenderingOff : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Force Rendering Off")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getForceRenderingOff;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getForceRenderingOff);
		}
		
		public override void Execute()
		{
			_getForceRenderingOff.Value = _renderer.Value.forceRenderingOff;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} forceRenderingOff -> {_getForceRenderingOff}";
		}
	}
}
