
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Describes how this renderer is updated for ray tracing.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-rayTracingMode.html")]
	public sealed class RendererSetRayTracingMode : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Ray Tracing Mode")]
		[SerializeField]
		private Rendering.RayTracingModeVar _setRayTracingMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setRayTracingMode);
		}
		
		public override void Execute()
		{
			_renderer.Value.rayTracingMode = _setRayTracingMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Ray Tracing Mode to {_setRayTracingMode}";
		}
	}
}
