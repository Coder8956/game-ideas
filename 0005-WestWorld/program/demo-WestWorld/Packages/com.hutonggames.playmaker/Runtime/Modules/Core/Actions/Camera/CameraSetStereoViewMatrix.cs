
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Sets a custom view matrix for a specific stereoscopic eye.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.SetStereoViewMatrix.html")]
	public sealed class CameraSetStereoViewMatrix : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Specifies the stereoscopic view matrix to set.")]
		[SerializeField]
		private Camera.StereoscopicEye _eye;
		
		[Tooltip("The matrix to be set.")]
		[SerializeField]
		private Matrix4x4Var _matrix;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _eye, _matrix);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.SetStereoViewMatrix(UnityEngine.Camera+StereoscopicEye, UnityEngine.Matrix4x4);
			_camera.Value.SetStereoViewMatrix(_eye, _matrix.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} stereo view matrix {_eye} to {_matrix}";
		}
	}
}
