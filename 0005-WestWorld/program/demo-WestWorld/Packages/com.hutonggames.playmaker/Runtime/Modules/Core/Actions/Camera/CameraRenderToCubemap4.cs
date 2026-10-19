
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ConvertibleGroup("CameraRenderToCubemap")]
	[ActionDescription("Render into a static cubemap from this camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.RenderToCubemap.html")]
	public sealed class CameraRenderToCubemap4 : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("The cube map to render to.")]
		[SerializeField]
		private RenderTextureVar _cubemap;
		
		[Tooltip("A bitmask which determines which of the six faces are rendered to.")]
		[SerializeField]
		private CubemapFaceVar _faceMask;
		
		[Tooltip("A Camera eye corresponding to the left or right eye for stereoscopic rendering, o" +
			"r neither for non-stereoscopic rendering.")]
		[SerializeField]
		private Camera_MonoOrStereoscopicEyeVar _stereoEye;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _succeeded;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _cubemap, _faceMask, _stereoEye, _succeeded);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.RenderToCubemap(UnityEngine.RenderTexture, System.Int32, UnityEngine.Camera+MonoOrStereoscopicEye);
			_succeeded.Value = _camera.Value.RenderToCubemap(_cubemap.Value, (int)_faceMask.Value, _stereoEye.Value);
		}
		
		public override string GetSummary()
		{
			return "Render {_camera} to cubemap {_cubemap} {_faceMask} {_stereoEye} -> {_succeeded}";
		}
	}
}
