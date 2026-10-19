
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Does this object cast shadows?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-shadowCastingMode.html")]
	public sealed class RendererGetShadowCastingMode : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Shadow Casting Mode")]
		[SerializeField]
		[WriteOnly]
		private Rendering.ShadowCastingModeRef _getShadowCastingMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getShadowCastingMode);
		}
		
		public override void Execute()
		{
			_getShadowCastingMode.Value = _renderer.Value.shadowCastingMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} shadowCastingMode -> {_getShadowCastingMode}";
		}
	}
}
