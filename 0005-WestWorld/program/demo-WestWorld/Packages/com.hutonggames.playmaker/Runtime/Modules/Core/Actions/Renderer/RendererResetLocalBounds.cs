
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Reset custom local space bounds.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer.ResetLocalBounds.html")]
	public sealed class RendererResetLocalBounds : BaseAction
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
			//UnityEngine.Renderer.ResetLocalBounds();
			_renderer.Value.ResetLocalBounds();
		}
		
		public override string GetSummary()
		{
			return "Reset Local Bounds {_renderer} ";
		}
	}
}
