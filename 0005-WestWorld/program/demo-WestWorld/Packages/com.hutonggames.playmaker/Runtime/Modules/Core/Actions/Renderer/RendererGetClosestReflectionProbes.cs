
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Returns an array of closest reflection probes with weights, weight shows how much" +
		" influence the probe has on the renderer, this value is also used when blending " +
		"between reflection probes occur.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer.GetClosestReflectionProbes.html" +
		"")]
	public sealed class RendererGetClosestReflectionProbes : BaseAction
	{
		
		[Tooltip("The Renderer.")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Result.")]
		[SerializeField]
		private Rendering.ReflectionProbeBlendInfoListRef _results;
		
		public override bool CanExecute() => CheckParameters(_renderer, _results);

		public override void Execute() => _renderer.Value.GetClosestReflectionProbes(_results.Value);

		public override string GetSummary() => "Get Closest Reflection Probes {_renderer} -> {_results} ";
	}
}
