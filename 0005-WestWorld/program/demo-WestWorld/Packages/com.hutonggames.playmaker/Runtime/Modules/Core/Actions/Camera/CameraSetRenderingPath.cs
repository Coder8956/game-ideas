
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The rendering path that should be used, if possible.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-renderingPath.html")]
	public sealed class CameraSetRenderingPath : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Rendering Path")]
		[SerializeField]
		private RenderingPathVar _setRenderingPath;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setRenderingPath);
		}
		
		public override void Execute()
		{
			_camera.Value.renderingPath = _setRenderingPath.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} rendering path to {_setRenderingPath}";
		}
	}
}
