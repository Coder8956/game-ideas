
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The rendering path that should be used, if possible.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-renderingPath.html")]
	public sealed class CameraGetRenderingPath : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Rendering Path")]
		[SerializeField]
		[WriteOnly]
		private RenderingPathRef _getRenderingPath;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getRenderingPath);
		}
		
		public override void Execute()
		{
			_getRenderingPath.Value = _camera.Value.renderingPath;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} rendering path -> {_getRenderingPath}";
		}
	}
}
