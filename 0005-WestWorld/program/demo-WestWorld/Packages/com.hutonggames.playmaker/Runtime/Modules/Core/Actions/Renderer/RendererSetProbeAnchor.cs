
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
	public sealed class RendererSetProbeAnchor : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Probe Anchor")]
		[SerializeField, CanBeNullOrEmpty]
		private TransformVar _setProbeAnchor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer);
		}
		
		public override void Execute()
		{
			_renderer.Value.probeAnchor = _setProbeAnchor.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Probe Anchor to {_setProbeAnchor}";
		}
	}
}
