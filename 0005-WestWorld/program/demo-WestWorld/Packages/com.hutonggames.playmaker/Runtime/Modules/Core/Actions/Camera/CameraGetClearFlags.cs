
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("How the camera clears the background.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-clearFlags.html")]
	public sealed class CameraGetClearFlags : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Clear Flags")]
		[SerializeField]
		[WriteOnly]
		private CameraClearFlagsRef _getClearFlags;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getClearFlags);
		}
		
		public override void Execute()
		{
			_getClearFlags.Value = _camera.Value.clearFlags;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} clear flags -> {_getClearFlags}";
		}
	}
}
