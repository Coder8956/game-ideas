
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Makes the rendered 3D object visible if enabled.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-enabled.html")]
	public sealed class RendererSetEnabled : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Enabled")]
		[SerializeField]
		private BoolVar _setEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setEnabled);
		}
		
		public override void Execute()
		{
			_renderer.Value.enabled = _setEnabled.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Enabled to {_setEnabled}";
		}
	}
}
