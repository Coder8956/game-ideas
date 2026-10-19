
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Indicates whether the renderer is part of a with other renderers.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-isPartOfStaticBatch.html")]
	public sealed class RendererGetIsPartOfStaticBatch : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Is Part Of Static Batch")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsPartOfStaticBatch;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getIsPartOfStaticBatch);
		}
		
		public override void Execute()
		{
			_getIsPartOfStaticBatch.Value = _renderer.Value.isPartOfStaticBatch;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} isPartOfStaticBatch -> {_getIsPartOfStaticBatch}";
		}
	}
}
