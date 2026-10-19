
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
	public sealed class CameraSetOrthographicSize : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Orthographic Size")]
		[SerializeField]
		private FloatVar _setOrthographicSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setOrthographicSize);
		}
		
		public override void Execute()
		{
			_camera.Value.orthographicSize = _setOrthographicSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} orthographic size to {_setOrthographicSize}";
		}
	}
}
