
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("How tall is the camera in pixels (not accounting for dynamic resolution scaling) " +
		"(Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-pixelHeight.html")]
	public sealed class CameraGetPixelHeight : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Pixel Height")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPixelHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getPixelHeight);
		}
		
		public override void Execute()
		{
			_getPixelHeight.Value = _camera.Value.pixelHeight;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} pixel height -> {_getPixelHeight}";
		}
	}
}
