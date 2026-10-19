
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Set the raw projection matrix with no camera offset (no jittering).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-nonJitteredProjectionMatrix.html")]
	public sealed class CameraSetNonJitteredProjectionMatrix : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Non Jittered Projection Matrix")]
		[SerializeField]
		private Matrix4x4Var _setNonJitteredProjectionMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setNonJitteredProjectionMatrix);
		}
		
		public override void Execute()
		{
			_camera.Value.nonJitteredProjectionMatrix = _setNonJitteredProjectionMatrix.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} non-jittered projection matrix to {_setNonJitteredProjectionMatrix}";
		}
	}
}
