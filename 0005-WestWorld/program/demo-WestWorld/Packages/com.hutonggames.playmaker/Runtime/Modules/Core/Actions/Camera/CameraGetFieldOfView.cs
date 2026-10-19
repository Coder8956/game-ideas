
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
	public sealed class CameraGetFieldOfView : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Field Of View")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFieldOfView;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getFieldOfView);
		}
		
		public override void Execute()
		{
			_getFieldOfView.Value = _camera.Value.fieldOfView;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} FOV -> {_getFieldOfView}";
		}
	}
}
