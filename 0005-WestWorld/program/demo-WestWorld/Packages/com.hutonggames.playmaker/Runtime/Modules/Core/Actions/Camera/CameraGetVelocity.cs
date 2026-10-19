
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Get the world-space speed of the camera (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-velocity.html")]
	public sealed class CameraGetVelocity : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Velocity")]
		[SerializeField]
		[WriteOnly]
		private Vector3Ref _getVelocity;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getVelocity);
		}
		
		public override void Execute()
		{
			_getVelocity.Value = _camera.Value.velocity;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} velocity -> {_getVelocity}";
		}
	}
}
