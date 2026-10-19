
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Calculates and returns oblique near-plane projection matrix.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.CalculateObliqueMatrix.html")]
	public sealed class CameraCalculateObliqueMatrix : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Vector4 that describes a clip plane.")]
		[SerializeField]
		private Vector4Var _clipPlane;
		
		[Tooltip("Store the result in Matrix4x4 variable.")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _clipPlane, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.CalculateObliqueMatrix(UnityEngine.Vector4);
			_result.Value = _camera.Value.CalculateObliqueMatrix(_clipPlane.Value);
		}
		
		public override string GetSummary()
		{
			return "Calculate {_camera} oblique matrix {_clipPlane} -> {_result}";
		}
	}
}
