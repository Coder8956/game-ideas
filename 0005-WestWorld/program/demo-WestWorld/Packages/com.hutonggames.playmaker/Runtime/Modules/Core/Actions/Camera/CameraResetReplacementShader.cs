
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Remove shader replacement from camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ResetReplacementShader.html")]
	public sealed class CameraResetReplacementShader : BaseAction
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
			//UnityEngine.Camera.ResetReplacementShader();
			_camera.Value.ResetReplacementShader();
		}
		
		public override string GetSummary()
		{
			return "Reset {_camera} replacement shader";
		}
	}
}
