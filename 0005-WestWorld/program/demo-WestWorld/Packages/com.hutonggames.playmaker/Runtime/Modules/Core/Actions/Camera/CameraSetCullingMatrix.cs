
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Sets a custom matrix for the camera to use for all culling queries.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-cullingMatrix.html")]
	public sealed class CameraSetCullingMatrix : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Culling Matrix")]
		[SerializeField]
		private Matrix4x4Var _setCullingMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setCullingMatrix);
		}
		
		public override void Execute()
		{
			_camera.Value.cullingMatrix = _setCullingMatrix.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} culling matrix to {_setCullingMatrix}";
		}
	}
}
