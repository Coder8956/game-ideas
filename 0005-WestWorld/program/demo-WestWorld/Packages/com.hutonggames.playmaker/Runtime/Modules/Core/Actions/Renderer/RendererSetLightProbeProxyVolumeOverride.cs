
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
	public sealed class RendererSetLightProbeProxyVolumeOverride : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Light Probe Proxy Volume Override")]
		[SerializeField, CanBeNullOrEmpty]
		private GameObjectVar _setLightProbeProxyVolumeOverride;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer);
		}
		
		public override void Execute()
		{
			_renderer.Value.lightProbeProxyVolumeOverride = _setLightProbeProxyVolumeOverride.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Light Probe Proxy Volume Override to {_setLightProbeProxyVolumeOverride}";
		}
	}
}
