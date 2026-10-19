
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Set a custom projection matrix.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-projectionMatrix.html")]
	public sealed class CameraSetProjectionMatrix : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Projection Matrix")]
		[SerializeField]
		private Matrix4x4Var _setProjectionMatrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setProjectionMatrix);
		}
		
		public override void Execute()
		{
			_camera.Value.projectionMatrix = _setProjectionMatrix.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} projection matrix to {_setProjectionMatrix}";
		}
	}
}
