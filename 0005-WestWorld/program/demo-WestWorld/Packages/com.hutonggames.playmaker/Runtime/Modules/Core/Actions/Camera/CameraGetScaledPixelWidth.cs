
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("How wide is the camera in pixels (accounting for dynamic resolution scaling) (Rea" +
		"d Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-scaledPixelWidth.html")]
	public sealed class CameraGetScaledPixelWidth : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Scaled Pixel Width")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getScaledPixelWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getScaledPixelWidth);
		}
		
		public override void Execute()
		{
			_getScaledPixelWidth.Value = _camera.Value.scaledPixelWidth;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} scaled pixel width -> {_getScaledPixelWidth}";
		}
	}
}
