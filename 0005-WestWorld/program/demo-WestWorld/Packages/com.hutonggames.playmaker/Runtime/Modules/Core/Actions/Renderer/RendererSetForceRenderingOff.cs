
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Allows turning off rendering for a specific component.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-forceRenderingOff.html")]
	public sealed class RendererSetForceRenderingOff : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Force Rendering Off")]
		[SerializeField]
		private BoolVar _setForceRenderingOff;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setForceRenderingOff);
		}
		
		public override void Execute()
		{
			_renderer.Value.forceRenderingOff = _setForceRenderingOff.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Force Rendering Off to {_setForceRenderingOff}";
		}
	}
}
