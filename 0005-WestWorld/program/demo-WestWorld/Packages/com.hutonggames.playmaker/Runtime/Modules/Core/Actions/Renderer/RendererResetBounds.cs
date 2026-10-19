
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Reset custom world space bounds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer.ResetBounds.html")]
	public sealed class RendererResetBounds : BaseAction
	{
		
		[Tooltip("The Renderer.")]
		[SerializeField]
		private RendererVar _renderer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer);
		}
		
		public override void Execute()
		{
			//UnityEngine.Renderer.ResetBounds();
			_renderer.Value.ResetBounds();
		}
		
		public override string GetSummary()
		{
			return "Reset Bounds {_renderer} ";
		}
	}
}
