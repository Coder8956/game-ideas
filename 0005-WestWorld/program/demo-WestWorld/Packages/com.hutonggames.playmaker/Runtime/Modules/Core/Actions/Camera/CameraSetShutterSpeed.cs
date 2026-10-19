
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The exposure time of the camera, in seconts. To use this property, enable UsePhys" +
		"icalProperties.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-shutterSpeed.html")]
	public sealed class CameraSetShutterSpeed : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Shutter Speed")]
		[SerializeField]
		private FloatVar _setShutterSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setShutterSpeed);
		}
		
		public override void Execute()
		{
			_camera.Value.shutterSpeed = _setShutterSpeed.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} shutter speed to {_setShutterSpeed}";
		}
	}
}
