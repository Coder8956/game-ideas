
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Is the camera orthographic (true) or perspective (false)?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-orthographic.html")]
	public sealed class CameraSetOrthographic : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Orthographic")]
		[SerializeField]
		private BoolVar _setOrthographic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setOrthographic);
		}
		
		public override void Execute()
		{
			_camera.Value.orthographic = _setOrthographic.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} orthographic to {_setOrthographic}";
		}
	}
}
