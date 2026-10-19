
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("How tall is the camera in pixels (accounting for dynamic resolution scaling) (Rea" +
		"d Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-scaledPixelHeight.html")]
	public sealed class CameraGetScaledPixelHeight : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Scaled Pixel Height")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getScaledPixelHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getScaledPixelHeight);
		}
		
		public override void Execute()
		{
			_getScaledPixelHeight.Value = _camera.Value.scaledPixelHeight;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} scaled pixel height -> {_getScaledPixelHeight}";
		}
	}
}
