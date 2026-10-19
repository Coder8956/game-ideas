
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The index of the baked lightmap applied to this renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-lightmapIndex.html")]
	public sealed class RendererGetLightmapIndex : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Lightmap Index")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getLightmapIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getLightmapIndex);
		}
		
		public override void Execute()
		{
			_getLightmapIndex.Value = _renderer.Value.lightmapIndex;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} lightmapIndex -> {_getLightmapIndex}";
		}
	}
}
