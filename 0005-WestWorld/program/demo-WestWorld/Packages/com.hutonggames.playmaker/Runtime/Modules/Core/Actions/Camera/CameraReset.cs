
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Revert all camera parameters to default.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.Reset.html")]
	public sealed class CameraReset : BaseAction
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
			//UnityEngine.Camera.Reset();
			_camera.Value.Reset();
		}
		
		public override string GetSummary()
		{
			return "Reset {_camera}";
		}
	}
}
