
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The light probe interpolation type.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-lightProbeUsage.html")]
	public sealed class RendererGetLightProbeUsage : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Light Probe Usage")]
		[SerializeField]
		[WriteOnly]
		private Rendering.LightProbeUsageRef _getLightProbeUsage;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getLightProbeUsage);
		}
		
		public override void Execute()
		{
			_getLightProbeUsage.Value = _renderer.Value.lightProbeUsage;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} lightProbeUsage -> {_getLightProbeUsage}";
		}
	}
}
