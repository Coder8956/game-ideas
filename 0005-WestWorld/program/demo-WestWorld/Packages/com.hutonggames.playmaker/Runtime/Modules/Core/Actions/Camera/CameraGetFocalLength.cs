
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The camera focal length, expressed in millimeters. To use this property, enable U" +
		"sePhysicalProperties.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-focalLength.html")]
	public sealed class CameraGetFocalLength : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Focal Length")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFocalLength;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getFocalLength);
		}
		
		public override void Execute()
		{
			_getFocalLength.Value = _camera.Value.focalLength;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} focal length -> {_getFocalLength}";
		}
	}
}
