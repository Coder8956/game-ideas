
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Does this object cast shadows?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-shadowCastingMode.html")]
	public sealed class RendererSetShadowCastingMode : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Shadow Casting Mode")]
		[SerializeField]
		private Rendering.ShadowCastingModeVar _setShadowCastingMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setShadowCastingMode);
		}
		
		public override void Execute()
		{
			_renderer.Value.shadowCastingMode = _setShadowCastingMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Shadow Casting Mode to {_setShadowCastingMode}";
		}
	}
}
