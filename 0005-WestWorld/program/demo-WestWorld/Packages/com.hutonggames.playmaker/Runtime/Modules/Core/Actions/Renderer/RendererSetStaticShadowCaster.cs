
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Is this renderer a static shadow caster?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-staticShadowCaster.html")]
	public sealed class RendererSetStaticShadowCaster : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Static Shadow Caster")]
		[SerializeField]
		private BoolVar _setStaticShadowCaster;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setStaticShadowCaster);
		}
		
		public override void Execute()
		{
			_renderer.Value.staticShadowCaster = _setStaticShadowCaster.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Static Shadow Caster to {_setStaticShadowCaster}";
		}
	}
}
