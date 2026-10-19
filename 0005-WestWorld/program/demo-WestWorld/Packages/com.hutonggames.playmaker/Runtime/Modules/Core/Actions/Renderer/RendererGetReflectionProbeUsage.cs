
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Should reflection probes be used for this Renderer?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-reflectionProbeUsage.html")]
	public sealed class RendererGetReflectionProbeUsage : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Reflection Probe Usage")]
		[SerializeField]
		[WriteOnly]
		private Rendering.ReflectionProbeUsageRef _getReflectionProbeUsage;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getReflectionProbeUsage);
		}
		
		public override void Execute()
		{
			_getReflectionProbeUsage.Value = _renderer.Value.reflectionProbeUsage;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} reflectionProbeUsage -> {_getReflectionProbeUsage}";
		}
	}
}
