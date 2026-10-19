
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Makes this camera\'s settings match other camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.CopyFrom.html")]
	public sealed class CameraCopyFrom : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Copy camera settings to the other camera.")]
		[SerializeField]
		private CameraVar _other;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _other);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.CopyFrom(UnityEngine.Camera);
			_camera.Value.CopyFrom(_other.Value);
		}
		
		public override string GetSummary()
		{
			return "Copy {_other} to {_camera}";
		}
	}
}
