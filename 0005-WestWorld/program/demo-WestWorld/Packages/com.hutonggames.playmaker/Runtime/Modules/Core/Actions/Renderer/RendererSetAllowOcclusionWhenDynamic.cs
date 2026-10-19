
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Controls if dynamic occlusion culling should be performed for this renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-allowOcclusionWhenDynamic.html")]
	public sealed class RendererSetAllowOcclusionWhenDynamic : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Allow Occlusion When Dynamic")]
		[SerializeField]
		private BoolVar _setAllowOcclusionWhenDynamic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setAllowOcclusionWhenDynamic);
		}
		
		public override void Execute()
		{
			_renderer.Value.allowOcclusionWhenDynamic = _setAllowOcclusionWhenDynamic.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Allow Occlusion When Dynamic to {_setAllowOcclusionWhenDynamic}";
		}
	}
}
