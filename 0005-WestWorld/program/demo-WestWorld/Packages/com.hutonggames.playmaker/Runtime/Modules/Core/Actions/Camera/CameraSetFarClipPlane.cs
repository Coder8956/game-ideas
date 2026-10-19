
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
	public sealed class CameraSetFarClipPlane : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Far Clip Plane")]
		[SerializeField]
		private FloatVar _setFarClipPlane;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setFarClipPlane);
		}
		
		public override void Execute()
		{
			_camera.Value.farClipPlane = _setFarClipPlane.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} far clip plane to {_setFarClipPlane}";
		}
	}
}
