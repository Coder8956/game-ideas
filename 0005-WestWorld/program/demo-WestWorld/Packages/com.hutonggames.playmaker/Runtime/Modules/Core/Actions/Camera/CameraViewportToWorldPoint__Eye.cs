
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ConvertibleGroup("CameraViewportToWorldPoint")]
	[ActionDescription("Transforms position from viewport space into world space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ViewportToWorldPoint.html")]
	public sealed class CameraViewportToWorldPoint__Eye : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("The 3d vector in Viewport space.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Eye.")]
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
			//UnityEngine.Camera.ViewportToWorldPoint(UnityEngine.Vector3, UnityEngine.Camera+MonoOrStereoscopicEye);
			_result.Value = _camera.Value.ViewportToWorldPoint(_position.Value, _eye.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert {_camera:hide} viewport point {_position} {_eye} to world point -> {_result}";
		}
	}
}
