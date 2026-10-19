
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The UV scale & offset used for a lightmap.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-lightmapScaleOffset.html")]
	public sealed class RendererGetLightmapScaleOffset : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Lightmap Scale Offset")]
		[SerializeField]
		[WriteOnly]
		private Vector4Ref _getLightmapScaleOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getLightmapScaleOffset);
		}
		
		public override void Execute()
		{
			_getLightmapScaleOffset.Value = _renderer.Value.lightmapScaleOffset;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} lightmapScaleOffset -> {_getLightmapScaleOffset}";
		}
	}
}
