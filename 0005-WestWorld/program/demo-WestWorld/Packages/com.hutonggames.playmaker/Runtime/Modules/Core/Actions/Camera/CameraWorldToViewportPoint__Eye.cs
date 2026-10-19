
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ConvertibleGroup("CameraWorldToViewportPoint")]
	[ActionDescription("Transforms position from world space into viewport space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.WorldToViewportPoint.html")]
	public sealed class CameraWorldToViewportPoint__Eye : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Position.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Optional argument that can be used to specify which eye transform to use. Default is Mono.")]
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
			//UnityEngine.Camera.WorldToViewportPoint(UnityEngine.Vector3, UnityEngine.Camera+MonoOrStereoscopicEye);
			_result.Value = _camera.Value.WorldToViewportPoint(_position.Value, _eye.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert {_camera:hide} world point {_position} {_eye} to viewport point -> {_result}";
		}
	}
}
