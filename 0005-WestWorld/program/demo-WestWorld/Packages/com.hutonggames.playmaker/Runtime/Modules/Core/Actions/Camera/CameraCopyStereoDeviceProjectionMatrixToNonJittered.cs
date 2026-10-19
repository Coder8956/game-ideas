
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Sets the non-jittered projection matrix, sourced from the VR SDK.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.CopyStereoDeviceProjectionMatrixT" +
		"oNonJittered.html")]
	public sealed class CameraCopyStereoDeviceProjectionMatrixToNonJittered : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Specifies the stereoscopic eye whose non-jittered projection matrix will be sourced from the VR SDK.")]
		[SerializeField]
		private Camera.StereoscopicEye _eye;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _eye);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.CopyStereoDeviceProjectionMatrixToNonJittered(UnityEngine.Camera+StereoscopicEye);
			_camera.Value.CopyStereoDeviceProjectionMatrixToNonJittered(_eye);
		}
		
		public override string GetSummary()
		{
			return "Copy {_camera} stereo device projection matrix {_eye} to non-jittered";
		}
	}
}
