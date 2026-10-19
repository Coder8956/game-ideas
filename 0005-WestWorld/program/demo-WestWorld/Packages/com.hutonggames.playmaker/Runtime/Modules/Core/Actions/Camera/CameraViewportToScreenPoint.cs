
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Transforms position from viewport space into screen space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ViewportToScreenPoint.html")]
	public sealed class CameraViewportToScreenPoint : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Position.")]
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
			//UnityEngine.Camera.ViewportToScreenPoint(UnityEngine.Vector3);
			_result.Value = _camera.Value.ViewportToScreenPoint(_position.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert {_camera:hide} viewport point {_position} to screen point -> {_result}";
		}
	}
}
