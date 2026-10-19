
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Reset the camera to using the Unity computed projection matrices for all stereosc" +
		"opic eyes.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ResetStereoProjectionMatrices.htm" +
		"l")]
	public sealed class CameraResetStereoProjectionMatrices : BaseAction
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
			//UnityEngine.Camera.ResetStereoProjectionMatrices();
			_camera.Value.ResetStereoProjectionMatrices();
		}
		
		public override string GetSummary()
		{
			return "Reset {_camera} stereo projection matrices";
		}
	}
}
