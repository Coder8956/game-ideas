
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Should reflection probes be used for this Renderer?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-reflectionProbeUsage.html")]
	public sealed class RendererSetReflectionProbeUsage : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Reflection Probe Usage")]
		[SerializeField]
		private Rendering.ReflectionProbeUsageVar _setReflectionProbeUsage;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setReflectionProbeUsage);
		}
		
		public override void Execute()
		{
			_renderer.Value.reflectionProbeUsage = _setReflectionProbeUsage.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Reflection Probe Usage to {_setReflectionProbeUsage}";
		}
	}
}
