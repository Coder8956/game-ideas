
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("How wide is the camera in pixels (not accounting for dynamic resolution scaling) " +
		"(Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-pixelWidth.html")]
	public sealed class CameraGetPixelWidth : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Pixel Width")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getPixelWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getPixelWidth);
		}
		
		public override void Execute()
		{
			_getPixelWidth.Value = _camera.Value.pixelWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} pixel width -> {_getPixelWidth}";
		}
	}
}
