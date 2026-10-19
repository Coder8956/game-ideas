
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Identifies what kind of camera this is, using the CameraType enum.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-cameraType.html")]
	public sealed class CameraSetCameraType : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Camera Type")]
		[SerializeField]
		private CameraTypeVar _setCameraType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setCameraType);
		}
		
		public override void Execute()
		{
			_camera.Value.cameraType = _setCameraType.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} camera type to {_setCameraType}";
		}
	}
}
