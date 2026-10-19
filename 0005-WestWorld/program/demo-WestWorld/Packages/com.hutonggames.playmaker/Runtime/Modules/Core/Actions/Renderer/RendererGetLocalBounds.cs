
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The bounding box of the renderer in local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-localBounds.html")]
	public sealed class RendererGetLocalBounds : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Local Bounds")]
		[SerializeField]
		[WriteOnly]
		private BoundsRef _getLocalBounds;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getLocalBounds);
		}
		
		public override void Execute()
		{
			_getLocalBounds.Value = _renderer.Value.localBounds;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} localBounds -> {_getLocalBounds}";
		}
	}
}
