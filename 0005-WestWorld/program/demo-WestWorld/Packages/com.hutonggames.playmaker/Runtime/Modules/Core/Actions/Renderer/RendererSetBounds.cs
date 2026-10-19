
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("The bounding box of the renderer in world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-bounds.html")]
	public sealed class RendererSetBounds : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Bounds")]
		[SerializeField]
		private BoundsVar _setBounds;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setBounds);
		}
		
		public override void Execute()
		{
			_renderer.Value.bounds = _setBounds.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Bounds to {_setBounds}";
		}
	}
}
