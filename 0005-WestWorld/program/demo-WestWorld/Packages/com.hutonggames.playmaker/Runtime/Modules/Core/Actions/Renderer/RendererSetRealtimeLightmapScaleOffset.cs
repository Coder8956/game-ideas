
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The UV scale & offset used for a real-time lightmap.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-realtimeLightmapScaleOffset.htm" +
		"l")]
	public sealed class RendererSetRealtimeLightmapScaleOffset : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Realtime Lightmap Scale Offset")]
		[SerializeField]
		private Vector4Var _setRealtimeLightmapScaleOffset;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setRealtimeLightmapScaleOffset);
		}
		
		public override void Execute()
		{
#pragma warning disable CS0618
			_renderer.Value.realtimeLightmapScaleOffset = _setRealtimeLightmapScaleOffset.Value;
#pragma warning restore CS0618
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Realtime Lightmap Scale Offset to {_setRealtimeLightmapScaleOffset}";
		}
	}
}
