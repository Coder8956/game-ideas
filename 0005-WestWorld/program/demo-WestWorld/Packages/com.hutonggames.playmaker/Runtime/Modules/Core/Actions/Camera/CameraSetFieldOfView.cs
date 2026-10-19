
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The vertical field of view of the Camera, in degrees.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-fieldOfView.html")]
	public sealed class CameraSetFieldOfView : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Field Of View")]
		[SerializeField, DefaultValue(60f)]
		private FloatVar _setFieldOfView;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setFieldOfView);
		}
		
		public override void Execute()
		{
			_camera.Value.fieldOfView = _setFieldOfView.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} FOV to {_setFieldOfView}";
		}
	}
}
