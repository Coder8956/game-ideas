
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The distance of the near clipping plane from the the Camera, in world units.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-nearClipPlane.html")]
	public sealed class CameraSetNearClipPlane : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Near Clip Plane")]
		[SerializeField]
		private FloatVar _setNearClipPlane;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setNearClipPlane);
		}
		
		public override void Execute()
		{
			_camera.Value.nearClipPlane = _setNearClipPlane.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} near clip plane to {_setNearClipPlane}";
		}
	}
}
