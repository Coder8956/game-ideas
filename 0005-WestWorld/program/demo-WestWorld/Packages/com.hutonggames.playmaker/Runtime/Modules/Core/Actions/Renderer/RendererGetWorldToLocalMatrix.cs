
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Renderer)]
	[ActionDescription("Matrix that transforms a point from world space into local space (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Renderer-worldToLocalMatrix.html")]
	public sealed class RendererGetWorldToLocalMatrix : BaseAction
	{
		
		[Tooltip("The Renderer")]
		[SerializeField]
		private RendererVar _renderer;
		
		[Tooltip("Get Renderer World To Local Matrix")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _getWorldToLocalMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_renderer, _getWorldToLocalMatrix);
		}
		
		public override void Execute()
		{
			_getWorldToLocalMatrix.Value = _renderer.Value.worldToLocalMatrix;
		}
		
		public override string GetSummary()
		{
			return "Get {_renderer} worldToLocalMatrix -> {_getWorldToLocalMatrix}";
		}
	}
}
