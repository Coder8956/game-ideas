
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
	public sealed class CameraGetShutterSpeed : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Shutter Speed")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getShutterSpeed;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getShutterSpeed);
		}
		
		public override void Execute()
		{
			_getShutterSpeed.Value = _camera.Value.shutterSpeed;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} shutter speed -> {_getShutterSpeed}";
		}
	}
}
