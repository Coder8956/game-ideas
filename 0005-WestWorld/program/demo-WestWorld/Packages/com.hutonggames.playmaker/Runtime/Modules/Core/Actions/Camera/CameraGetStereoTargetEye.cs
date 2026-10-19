
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Defines which eye of a VR display the Camera renders into.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-stereoTargetEye.html")]
	public sealed class CameraGetStereoTargetEye : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Stereo Target Eye")]
		[SerializeField]
		[WriteOnly]
		private StereoTargetEyeMaskRef _getStereoTargetEye;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getStereoTargetEye);
		}
		
		public override void Execute()
		{
			_getStereoTargetEye.Value = _camera.Value.stereoTargetEye;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} stereo target eye -> {_getStereoTargetEye}";
		}
	}
}
