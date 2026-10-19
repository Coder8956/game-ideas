
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Matrix that transforms from world to camera space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-worldToCameraMatrix.html")]
	public sealed class CameraGetWorldToCameraMatrix : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera World To Camera Matrix")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _getWorldToCameraMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getWorldToCameraMatrix);
		}
		
		public override void Execute()
		{
			_getWorldToCameraMatrix.Value = _camera.Value.worldToCameraMatrix;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} world to camera matrix -> {_getWorldToCameraMatrix}";
		}
	}
}
