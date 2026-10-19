
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Specifies the mode for motion vector rendering.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-motionVectorGenerationMode.html" +
		"")]
	public sealed class RendererGetMotionVectorGenerationMode : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Motion Vector Generation Mode")]
		[SerializeField]
		[WriteOnly]
		private MotionVectorGenerationModeRef _getMotionVectorGenerationMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getMotionVectorGenerationMode);
		}
		
		public override void Execute()
		{
			_getMotionVectorGenerationMode.Value = _renderer.Value.motionVectorGenerationMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} motionVectorGenerationMode -> {_getMotionVectorGenerationMode}";
		}
	}
}
