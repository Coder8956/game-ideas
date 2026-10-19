
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Set a custom projection matrix.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-projectionMatrix.html")]
	public sealed class CameraGetProjectionMatrix : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Projection Matrix")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _getProjectionMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getProjectionMatrix);
		}
		
		public override void Execute()
		{
			_getProjectionMatrix.Value = _camera.Value.projectionMatrix;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} projection matrix -> {_getProjectionMatrix}";
		}
	}
}
