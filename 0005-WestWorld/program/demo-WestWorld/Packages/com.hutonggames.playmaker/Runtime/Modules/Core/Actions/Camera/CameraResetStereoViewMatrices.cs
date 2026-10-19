
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Reset the camera to using the Unity computed view matrices for all stereoscopic e" +
		"yes.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ResetStereoViewMatrices.html")]
	public sealed class CameraResetStereoViewMatrices : BaseAction
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
			//UnityEngine.Camera.ResetStereoViewMatrices();
			_camera.Value.ResetStereoViewMatrices();
		}
		
		public override string GetSummary()
		{
			return "Reset {_camera} stereo view matrices";
		}
	}
}
