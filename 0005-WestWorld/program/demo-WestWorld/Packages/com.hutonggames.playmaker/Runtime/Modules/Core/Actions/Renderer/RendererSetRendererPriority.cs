
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
	public sealed class RendererSetRendererPriority : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Renderer Priority")]
		[SerializeField]
		private IntegerVar _setRendererPriority;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setRendererPriority);
		}
		
		public override void Execute()
		{
			_renderer.Value.rendererPriority = _setRendererPriority.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Renderer Priority to {_setRendererPriority}";
		}
	}
}
