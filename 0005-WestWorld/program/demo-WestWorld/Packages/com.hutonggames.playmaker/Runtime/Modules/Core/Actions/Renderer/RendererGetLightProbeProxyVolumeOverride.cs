
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("If set, the Renderer will use the Light Probe Proxy Volume component attached to " +
		"the source GameObject.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-lightProbeProxyVolumeOverride.h" +
		"tml")]
	public sealed class RendererGetLightProbeProxyVolumeOverride : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Light Probe Proxy Volume Override")]
		[SerializeField]
		[WriteOnly]
		private GameObjectRef _getLightProbeProxyVolumeOverride;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getLightProbeProxyVolumeOverride);
		}
		
		public override void Execute()
		{
			_getLightProbeProxyVolumeOverride.Value = _renderer.Value.lightProbeProxyVolumeOverride;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} lightProbeProxyVolumeOverride -> {_getLightProbeProxyVolumeOverride}";
		}
	}
}
