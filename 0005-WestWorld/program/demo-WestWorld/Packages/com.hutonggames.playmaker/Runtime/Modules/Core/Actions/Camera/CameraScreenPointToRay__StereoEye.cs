
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Returns a ray going from camera through a screen point." +
	                   "\n\nResulting ray is in world space, starting on the near plane of the camera and going " +
	                   "through position's (x,y) pixel coordinates on the screen (position.z is ignored)." +
	                   "\n\nScreenspace is defined in pixels. The bottom-left of the screen is (0,0); " +
	                   "the right-top is (pixelWidth -1,pixelHeight -1).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ScreenPointToRay.html")]
	public sealed class CameraScreenPointToRay__StereoEye : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField, DefaultValue("~MainCamera")]
		private CameraVar _camera;
		
		[Tooltip("A 3D point, with the x and y coordinates containing a 2D screenspace point in pixels. " +
		         "The lower left pixel of the screen is (0,0). The upper right pixel of the screen is " +
		         "(screen width in pixels - 1, screen height in pixels - 1). Unity ignores the z coordinate.")]
		[SerializeField]
		private Vector3Var _screenPoint;
		
		[Tooltip("Optional argument that can be used to specify which eye transform to use. Default is Mono.")]
		[SerializeField]
		private Camera_MonoOrStereoscopicEyeVar _eye;
		
		[Tooltip("Store the result in Ray variable.")]
		[SerializeField]
		[WriteOnly]
		private RayRef _ray;
		
		public override bool CanExecute() => CheckParameters(_camera, _screenPoint, _eye, _ray);

		public override void Execute() => 
			_ray.Value = _camera.Value.ScreenPointToRay(_screenPoint.Value, _eye.Value);

		public override string GetSummary() => _camera.Value == Camera.main
			? "Convert screen point {_screenPoint} {_eye} to ray -> {_ray}"
			: "Convert {_camera} screen point {_screenPoint} {_eye} to ray -> {_ray}";
	}
}
