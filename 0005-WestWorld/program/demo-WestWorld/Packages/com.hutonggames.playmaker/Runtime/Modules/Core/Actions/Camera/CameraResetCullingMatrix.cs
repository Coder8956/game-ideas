
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Make culling queries reflect the camera\'s built in parameters.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ResetCullingMatrix.html")]
	public sealed class CameraResetCullingMatrix : BaseAction
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
			//UnityEngine.Camera.ResetCullingMatrix();
			_camera.Value.ResetCullingMatrix();
		}
		
		public override string GetSummary()
		{
			return "Reset {_camera} culling matrix";
		}
	}
}
