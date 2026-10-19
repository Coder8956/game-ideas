
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Returns a ray going from camera through a viewport point." +
	                   "\n\nResulting ray is in world space, starting on the near plane of the camera and " +
	                   "going through position's (x,y) coordinates on the viewport (position.z is ignored)." +
	                   "\n\nViewport coordinates are normalized and relative to the camera. " +
	                   "The bottom-left of the camera is (0,0); the top-right is (1,1).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ViewportPointToRay.html")]
	public sealed class CameraViewportPointToRay__Eye : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Viewport position in normalized coordinates. " +
		         "The bottom-left of the camera is (0,0); the top-right is (1,1).")]
		[SerializeField]
		private Vector3Var _viewportPoint;
		
		[Tooltip("Optional argument that can be used to specify which eye transform to use. Default is Mono.")]
		[SerializeField]
		private Camera_MonoOrStereoscopicEyeVar _eye;
		
		[Tooltip("Store the result in Ray variable.")]
		[SerializeField]
		[WriteOnly]
		private RayRef _ray;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _viewportPoint, _eye, _ray);
		}
		
		public override void Execute()
		{
			_ray.Value = _camera.Value.ViewportPointToRay(_viewportPoint.Value, _eye.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert {_camera:hide} viewport point {_viewportPoint} {_eye} to ray -> {_ray}";
		}
	}
}
