
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Is this renderer a static shadow caster?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-staticShadowCaster.html")]
	public sealed class RendererGetStaticShadowCaster : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Static Shadow Caster")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getStaticShadowCaster;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getStaticShadowCaster);
		}
		
		public override void Execute()
		{
			_getStaticShadowCaster.Value = _renderer.Value.staticShadowCaster;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} staticShadowCaster -> {_getStaticShadowCaster}";
		}
	}
}
