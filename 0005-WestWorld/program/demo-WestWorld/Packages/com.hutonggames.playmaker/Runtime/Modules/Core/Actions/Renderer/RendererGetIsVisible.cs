
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Is this renderer visible in any camera? (Read Only)")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-isVisible.html")]
	public sealed class RendererGetIsVisible : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Is Visible")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getIsVisible;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getIsVisible);
		}
		
		public override void Execute()
		{
			_getIsVisible.Value = _renderer.Value.isVisible;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} isVisible -> {_getIsVisible}";
		}
	}
}
