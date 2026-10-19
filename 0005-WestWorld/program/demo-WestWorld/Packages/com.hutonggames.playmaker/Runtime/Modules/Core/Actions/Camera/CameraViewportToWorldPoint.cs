
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
	public sealed class CameraViewportToWorldPoint : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("The 3d vector in Viewport space.")]
		[SerializeField]
		private Vector3Var _position;
		
		[Tooltip("Store the result in Vector3 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _position, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.ViewportToWorldPoint(UnityEngine.Vector3);
			_result.Value = _camera.Value.ViewportToWorldPoint(_position.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert {_camera:hide} viewport point {_position} to world point -> {_result}";
		}
	}
}
