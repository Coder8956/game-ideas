
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Revert the aspect ratio to the screen\'s aspect ratio.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ResetAspect.html")]
	public sealed class CameraResetAspect : BaseAction
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
			//UnityEngine.Camera.ResetAspect();
			_camera.Value.ResetAspect();
		}
		
		public override string GetSummary()
		{
			return "Reset {_camera} aspect";
		}
	}
}
