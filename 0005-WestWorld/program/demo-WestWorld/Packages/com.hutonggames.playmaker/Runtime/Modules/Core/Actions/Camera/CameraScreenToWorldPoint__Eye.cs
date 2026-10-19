
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ConvertibleGroup("CameraScreenToWorldPoint")]
	[ActionDescription("Transforms a point from screen space into world space, where world space is defin" +
		"ed as the coordinate system at the very top of your game\'s hierarchy.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ScreenToWorldPoint.html")]
	public sealed class CameraScreenToWorldPoint__Eye : BaseAction
	{
		[Tooltip("The Camera.")]
		[DefaultValue("~MainCamera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("A screen space position (often mouse x, y), plus a z position for depth (for exam" +
			"ple, a camera clipping plane).")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("By default, Camera.MonoOrStereoscopicEye.Mono. Can be set to Camera.MonoOrStereos" +
			"copicEye.Left or Camera.MonoOrStereoscopicEye.Right for use in stereoscopic rend" +
			"ering (e.g., for VR).")]
		[SerializeField]
		private Camera_MonoOrStereoscopicEyeVar _eye;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _position, _eye, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.ScreenToWorldPoint(UnityEngine.Vector3, UnityEngine.Camera+MonoOrStereoscopicEye);
			_result.Value = _camera.Value.ScreenToWorldPoint(_position.Value, _eye.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert {_camera} screen point {_position} {_eye} to world point -> {_result}";
		}
	}
}
