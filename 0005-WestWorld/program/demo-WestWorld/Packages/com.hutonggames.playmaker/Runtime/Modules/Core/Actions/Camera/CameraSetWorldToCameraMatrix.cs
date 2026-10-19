
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Matrix that transforms from world to camera space.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-worldToCameraMatrix.html")]
	public sealed class CameraSetWorldToCameraMatrix : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera World To Camera Matrix")]
		[SerializeField]
		private Matrix4x4Var _setWorldToCameraMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setWorldToCameraMatrix);
		}
		
		public override void Execute()
		{
			_camera.Value.worldToCameraMatrix = _setWorldToCameraMatrix.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} world to camera matrix to {_setWorldToCameraMatrix}";
		}
	}
}
