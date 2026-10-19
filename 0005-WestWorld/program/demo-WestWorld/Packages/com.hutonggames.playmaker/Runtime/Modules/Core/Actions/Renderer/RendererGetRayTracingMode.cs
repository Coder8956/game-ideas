
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Describes how this renderer is updated for ray tracing.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-rayTracingMode.html")]
	public sealed class RendererGetRayTracingMode : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Ray Tracing Mode")]
		[SerializeField]
		[WriteOnly]
		private Rendering.RayTracingModeRef _getRayTracingMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getRayTracingMode);
		}
		
		public override void Execute()
		{
			_getRayTracingMode.Value = _renderer.Value.rayTracingMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} rayTracingMode -> {_getRayTracingMode}";
		}
	}
}
