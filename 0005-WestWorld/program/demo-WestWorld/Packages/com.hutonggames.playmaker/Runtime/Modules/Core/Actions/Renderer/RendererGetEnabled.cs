
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Makes the rendered 3D object visible if enabled.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-enabled.html")]
	public sealed class RendererGetEnabled : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Enabled")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getEnabled);
		}
		
		public override void Execute()
		{
			_getEnabled.Value = _renderer.Value.enabled;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} enabled -> {_getEnabled}";
		}
	}
}
