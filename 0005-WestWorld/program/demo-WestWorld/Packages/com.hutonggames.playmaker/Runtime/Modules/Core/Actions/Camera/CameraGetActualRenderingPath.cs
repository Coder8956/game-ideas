
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The rendering path that is currently being used (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-actualRenderingPath.html")]
	public sealed class CameraGetActualRenderingPath : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Actual Rendering Path")]
		[SerializeField]
		[WriteOnly]
		private RenderingPathRef _getActualRenderingPath;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getActualRenderingPath);
		}
		
		public override void Execute()
		{
			_getActualRenderingPath.Value = _camera.Value.actualRenderingPath;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} actual rendering path -> {_getActualRenderingPath}";
		}
	}
}
