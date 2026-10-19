
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Sets a custom projection matrix for a specific stereoscopic eye.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.SetStereoProjectionMatrix.html")]
	public sealed class CameraSetStereoProjectionMatrix : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Specifies the stereoscopic eye whose projection matrix needs to be set.")]
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
			//UnityEngine.Camera.SetStereoProjectionMatrix(UnityEngine.Camera+StereoscopicEye, UnityEngine.Matrix4x4);
			_camera.Value.SetStereoProjectionMatrix(_eye, _matrix.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} stereo projection matrix {_eye} to {_matrix}";
		}
	}
}
