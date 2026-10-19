
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("If set, Renderer will use this Transform\'s position to find the light or reflecti" +
		"on probe.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-probeAnchor.html")]
	public sealed class RendererGetProbeAnchor : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Probe Anchor")]
		[SerializeField]
		[WriteOnly]
		private TransformVar _getProbeAnchor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getProbeAnchor);
		}
		
		public override void Execute()
		{
			_getProbeAnchor.Value = _renderer.Value.probeAnchor;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} probeAnchor -> {_getProbeAnchor}";
		}
	}
}
