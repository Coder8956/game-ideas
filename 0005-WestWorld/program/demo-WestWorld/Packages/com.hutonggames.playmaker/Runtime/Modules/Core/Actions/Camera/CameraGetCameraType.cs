
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Identifies what kind of camera this is, using the CameraType enum.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-cameraType.html")]
	public sealed class CameraGetCameraType : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Camera Type")]
		[SerializeField]
		[WriteOnly]
		private CameraTypeRef _getCameraType;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getCameraType);
		}
		
		public override void Execute()
		{
			_getCameraType.Value = _camera.Value.cameraType;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} camera type -> {_getCameraType}";
		}
	}
}
