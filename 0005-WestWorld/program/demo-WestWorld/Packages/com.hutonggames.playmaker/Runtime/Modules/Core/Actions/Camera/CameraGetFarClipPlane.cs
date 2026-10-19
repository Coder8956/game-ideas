
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The distance of the far clipping plane from the Camera, in world units.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-farClipPlane.html")]
	public sealed class CameraGetFarClipPlane : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Far Clip Plane")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFarClipPlane;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getFarClipPlane);
		}
		
		public override void Execute()
		{
			_getFarClipPlane.Value = _camera.Value.farClipPlane;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} farClipPlane -> {_getFarClipPlane}";
		}
	}
}
