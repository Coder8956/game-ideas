
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Make the projection reflect normal camera\'s parameters.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ResetProjectionMatrix.html")]
	public sealed class CameraResetProjectionMatrix : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.ResetProjectionMatrix();
			_camera.Value.ResetProjectionMatrix();
		}
		
		public override string GetSummary()
		{
			return "Reset {_camera} projection matrix";
		}
	}
}
