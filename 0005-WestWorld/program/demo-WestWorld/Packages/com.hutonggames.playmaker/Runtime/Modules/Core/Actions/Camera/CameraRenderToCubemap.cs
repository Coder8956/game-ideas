
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
	public sealed class CameraRenderToCubemap : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("The cube map to render to.")]
		[SerializeField]
		private CubemapVar _cubemap;
		
		[Tooltip("A bitmask which determines which of the six faces are rendered to.")]
		[SerializeField]
		private CubemapFaceVar _faceMask;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _succeeded;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _cubemap, _succeeded);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.RenderToCubemap(UnityEngine.Cubemap, System.Int32);
			_succeeded.Value = _camera.Value.RenderToCubemap(_cubemap.Value, (int)_faceMask.Value);
		}
		
		public override string GetSummary()
		{
			return "Render {_camera} to cubemap {_cubemap} {_faceMask} -> {_succeeded}";
		}
	}
}
