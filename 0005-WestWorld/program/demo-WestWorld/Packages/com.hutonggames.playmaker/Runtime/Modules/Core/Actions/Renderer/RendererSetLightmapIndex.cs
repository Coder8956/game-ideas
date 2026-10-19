
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The index of the baked lightmap applied to this renderer.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-lightmapIndex.html")]
	public sealed class RendererSetLightmapIndex : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Lightmap Index")]
		[SerializeField]
		private IntegerVar _setLightmapIndex;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setLightmapIndex);
		}
		
		public override void Execute()
		{
			_renderer.Value.lightmapIndex = _setLightmapIndex.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Lightmap Index to {_setLightmapIndex}";
		}
	}
}
