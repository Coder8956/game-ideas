
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("How the camera clears the background.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-clearFlags.html")]
	public sealed class CameraSetClearFlags : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Clear Flags")]
		[SerializeField]
		private CameraClearFlagsVar _setClearFlags;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setClearFlags);
		}
		
		public override void Execute()
		{
			_camera.Value.clearFlags = _setClearFlags.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} clear flags to {_setClearFlags}";
		}
	}
}
