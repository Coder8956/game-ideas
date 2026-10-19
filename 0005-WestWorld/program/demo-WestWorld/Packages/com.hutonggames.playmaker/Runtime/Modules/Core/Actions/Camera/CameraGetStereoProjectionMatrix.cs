
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The projection matrix of the specified stereoscopic eye.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.GetStereoProjectionMatrix.html")]
	public sealed class CameraGetStereoProjectionMatrix : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Eye.")]
		[SerializeField]
		private Camera.StereoscopicEye _eye;
		
		[Tooltip("Store the result in Matrix4x4 variable.")]
		[SerializeField]
		[WriteOnly]
		private Matrix4x4Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _eye, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.GetStereoProjectionMatrix(UnityEngine.Camera+StereoscopicEye);
			_result.Value = _camera.Value.GetStereoProjectionMatrix(_eye);
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} stereo projection matrix {_eye} -> {_result}";
		}
	}
}
