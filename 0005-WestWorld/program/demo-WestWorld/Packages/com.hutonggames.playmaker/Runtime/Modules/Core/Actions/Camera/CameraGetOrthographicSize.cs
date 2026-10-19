
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Camera\'s half-size when in orthographic mode.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-orthographicSize.html")]
	public sealed class CameraGetOrthographicSize : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Orthographic Size")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getOrthographicSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getOrthographicSize);
		}
		
		public override void Execute()
		{
			_getOrthographicSize.Value = _camera.Value.orthographicSize;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} orthographic size -> {_getOrthographicSize}";
		}
	}
}
