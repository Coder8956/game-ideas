
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Defines which eye of a VR display the Camera renders into.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-stereoTargetEye.html")]
	public sealed class CameraSetStereoTargetEye : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Stereo Target Eye")]
		[SerializeField]
		private StereoTargetEyeMaskVar _setStereoTargetEye;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setStereoTargetEye);
		}
		
		public override void Execute()
		{
			_camera.Value.stereoTargetEye = _setStereoTargetEye.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} stereo target eye to {_setStereoTargetEye}";
		}
	}
}
