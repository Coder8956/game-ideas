
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Sets a custom matrix for the camera to use for all culling queries.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-cullingMatrix.html")]
	public sealed class CameraGetCullingMatrix : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Culling Matrix")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _getCullingMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getCullingMatrix);
		}
		
		public override void Execute()
		{
			_getCullingMatrix.Value = _camera.Value.cullingMatrix;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} culling matrix -> {_getCullingMatrix}";
		}
	}
}
