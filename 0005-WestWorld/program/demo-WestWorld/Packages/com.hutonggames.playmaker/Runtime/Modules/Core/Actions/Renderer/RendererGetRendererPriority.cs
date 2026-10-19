
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("This value sorts renderers by priority. Lower values are rendered first and highe" +
		"r values are rendered last.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-rendererPriority.html")]
	public sealed class RendererGetRendererPriority : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Renderer Priority")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getRendererPriority;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getRendererPriority);
		}
		
		public override void Execute()
		{
			_getRendererPriority.Value = _renderer.Value.rendererPriority;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} rendererPriority -> {_getRendererPriority}";
		}
	}
}
