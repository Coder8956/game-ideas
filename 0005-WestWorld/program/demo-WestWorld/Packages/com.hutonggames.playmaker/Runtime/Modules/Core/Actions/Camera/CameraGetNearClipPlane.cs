
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
	public sealed class CameraGetNearClipPlane : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Near Clip Plane")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getNearClipPlane;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getNearClipPlane);
		}
		
		public override void Execute()
		{
			_getNearClipPlane.Value = _camera.Value.nearClipPlane;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} near clip plane -> {_getNearClipPlane}";
		}
	}
}
