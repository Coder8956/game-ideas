
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
    [ConvertibleGroup("CameraWorldToScreenPoint")]
	[ActionDescription("Transforms position from world space into screen space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.WorldToScreenPoint.html")]
	public sealed class CameraWorldToScreenPoint : BaseAction
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
			//UnityEngine.Camera.WorldToScreenPoint(UnityEngine.Vector3);
			_result.Value = _camera.Value.WorldToScreenPoint(_position.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert {_camera:hide} world point {_position} to screen point -> {_result}";
		}
	}
}
