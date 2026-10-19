
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Make the rendering position reflect the camera\'s position in the Scene.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ResetWorldToCameraMatrix.html")]
	public sealed class CameraResetWorldToCameraMatrix : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.ResetWorldToCameraMatrix();
			_camera.Value.ResetWorldToCameraMatrix();
		}
		
		public override string GetSummary()
		{
			return "Reset {_camera} world to camera matrix";
		}
	}
}
