
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Matrix that transforms a point from local space into world space (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-localToWorldMatrix.html")]
	public sealed class RendererGetLocalToWorldMatrix : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer Local To World Matrix")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _getLocalToWorldMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getLocalToWorldMatrix);
		}
		
		public override void Execute()
		{
			_getLocalToWorldMatrix.Value = _renderer.Value.localToWorldMatrix;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} localToWorldMatrix -> {_getLocalToWorldMatrix}";
		}
	}
}
