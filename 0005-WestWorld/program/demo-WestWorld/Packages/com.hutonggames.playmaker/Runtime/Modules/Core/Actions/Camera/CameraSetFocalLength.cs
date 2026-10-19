
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
	public sealed class CameraSetFocalLength : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Focal Length")]
		[SerializeField]
		private FloatVar _setFocalLength;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setFocalLength);
		}
		
		public override void Execute()
		{
			_camera.Value.focalLength = _setFocalLength.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} focal length to {_setFocalLength}";
		}
	}
}
