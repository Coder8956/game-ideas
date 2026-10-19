
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Matrix that transforms from camera space to world space (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-cameraToWorldMatrix.html")]
	public sealed class CameraGetCameraToWorldMatrix : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Camera To World Matrix")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _getCameraToWorldMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getCameraToWorldMatrix);
		}
		
		public override void Execute()
		{
			_getCameraToWorldMatrix.Value = _camera.Value.cameraToWorldMatrix;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} camera to world matrix -> {_getCameraToWorldMatrix}";
		}
	}
}
