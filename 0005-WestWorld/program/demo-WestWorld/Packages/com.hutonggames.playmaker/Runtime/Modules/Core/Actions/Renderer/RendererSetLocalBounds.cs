
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The bounding box of the renderer in local space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-localBounds.html")]
	public sealed class RendererSetLocalBounds : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Local Bounds")]
		[SerializeField]
		private BoundsVar _setLocalBounds;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setLocalBounds);
		}
		
		public override void Execute()
		{
			_renderer.Value.localBounds = _setLocalBounds.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Local Bounds to {_setLocalBounds}";
		}
	}
}
