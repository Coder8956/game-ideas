
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The UV scale & offset used for a lightmap.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-lightmapScaleOffset.html")]
	public sealed class RendererSetLightmapScaleOffset : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Lightmap Scale Offset")]
		[SerializeField]
		private Vector4Var _setLightmapScaleOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setLightmapScaleOffset);
		}
		
		public override void Execute()
		{
			_renderer.Value.lightmapScaleOffset = _setLightmapScaleOffset.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Lightmap Scale Offset to {_setLightmapScaleOffset}";
		}
	}
}
