
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The light probe interpolation type.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-lightProbeUsage.html")]
	public sealed class RendererSetLightProbeUsage : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Light Probe Usage")]
		[SerializeField]
		private Rendering.LightProbeUsageVar _setLightProbeUsage;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setLightProbeUsage);
		}
		
		public override void Execute()
		{
			_renderer.Value.lightProbeUsage = _setLightProbeUsage.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Light Probe Usage to {_setLightProbeUsage}";
		}
	}
}
