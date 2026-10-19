
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Controls if dynamic occlusion culling should be performed for this renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-allowOcclusionWhenDynamic.html")]
	public sealed class RendererGetAllowOcclusionWhenDynamic : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Allow Occlusion When Dynamic")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAllowOcclusionWhenDynamic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getAllowOcclusionWhenDynamic);
		}
		
		public override void Execute()
		{
			_getAllowOcclusionWhenDynamic.Value = _renderer.Value.allowOcclusionWhenDynamic;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} allowOcclusionWhenDynamic -> {_getAllowOcclusionWhenDynamic}";
		}
	}
}
