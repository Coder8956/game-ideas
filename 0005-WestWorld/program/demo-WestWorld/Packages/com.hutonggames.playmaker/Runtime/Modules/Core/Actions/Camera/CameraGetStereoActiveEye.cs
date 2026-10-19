
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription(@"Returns the eye that is currently rendering. If called when stereo is not enabled it will return Camera.MonoOrStereoscopicEye.Mono. If called during a camera rendering callback such as OnRenderImage it will return the currently rendering eye. If called outside of a rendering callback and stereo is enabled, it will return the default eye which is Camera.MonoOrStereoscopicEye.Left.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-stereoActiveEye.html")]
	public sealed class CameraGetStereoActiveEye : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Stereo Active Eye")]
		[SerializeField]
		[WriteOnly]
		private Camera_MonoOrStereoscopicEyeRef _getStereoActiveEye;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getStereoActiveEye);
		}
		
		public override void Execute()
		{
			_getStereoActiveEye.Value = _camera.Value.stereoActiveEye;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} stereo active eye -> {_getStereoActiveEye}";
		}
	}
}
