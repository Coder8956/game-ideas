
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The bounding box of the renderer in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-bounds.html")]
	public sealed class RendererGetBounds : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Bounds")]
		[SerializeField]
		[WriteOnly]
		private BoundsRef _getBounds;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getBounds);
		}
		
		public override void Execute()
		{
			_getBounds.Value = _renderer.Value.bounds;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} bounds -> {_getBounds}";
		}
	}
}
