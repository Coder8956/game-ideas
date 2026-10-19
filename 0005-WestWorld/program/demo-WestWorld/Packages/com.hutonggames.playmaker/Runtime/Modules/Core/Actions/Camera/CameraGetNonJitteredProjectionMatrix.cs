
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Get the raw projection matrix with no camera offset (no jittering).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-nonJitteredProjectionMatrix.html")]
	public sealed class CameraGetNonJitteredProjectionMatrix : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Non Jittered Projection Matrix")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _getNonJitteredProjectionMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getNonJitteredProjectionMatrix);
		}
		
		public override void Execute()
		{
			_getNonJitteredProjectionMatrix.Value = _camera.Value.nonJitteredProjectionMatrix;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} non-jittered projection matrix -> {_getNonJitteredProjectionMatrix}";
		}
	}
}
