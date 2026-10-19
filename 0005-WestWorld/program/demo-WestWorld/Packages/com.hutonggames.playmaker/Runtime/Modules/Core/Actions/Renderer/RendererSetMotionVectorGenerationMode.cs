
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
	public sealed class RendererSetMotionVectorGenerationMode : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Set Renderer Motion Vector Generation Mode")]
		[SerializeField]
		private MotionVectorGenerationModeVar _setMotionVectorGenerationMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _setMotionVectorGenerationMode);
		}
		
		public override void Execute()
		{
			_renderer.Value.motionVectorGenerationMode = _setMotionVectorGenerationMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_renderer} Motion Vector Generation Mode to {_setMotionVectorGenerationMode}";
		}
	}
}
