
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The index of the real-time lightmap applied to this renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-realtimeLightmapIndex.html")]
	public sealed class RendererSetRealtimeLightmapIndex : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Realtime Lightmap Index")]
		[SerializeField]
		private IntegerVar _setRealtimeLightmapIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setRealtimeLightmapIndex);
		}
		
		public override void Execute()
		{
#pragma warning disable CS0618
			_renderer.Value.realtimeLightmapIndex = _setRealtimeLightmapIndex.Value;
#pragma warning restore CS0618
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Realtime Lightmap Index to {_setRealtimeLightmapIndex}";
		}
	}
}
