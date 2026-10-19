
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ConvertibleGroup("CameraRenderToCubemap")]
	[ActionDescription("Render into a cubemap from this camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.RenderToCubemap.html")]
	public sealed class CameraRenderToCubemap2 : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("The texture to render to.")]
		[SerializeField]
		private RenderTextureVar _cubemap;
		
		[Tooltip("A bitfield indicating which cubemap faces should be rendered into.")]
		[SerializeField]
		private CubemapFaceVar _faceMask;
		
		[Tooltip("Store the result in Bool variable.")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _succeeded;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _cubemap, _faceMask, _succeeded);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.RenderToCubemap(UnityEngine.RenderTexture, System.Int32);
			_succeeded.Value = _camera.Value.RenderToCubemap(_cubemap.Value, (int)_faceMask.Value);
		}
		
		public override string GetSummary()
		{
			return "Render {_camera} to cubemap {_cubemap} {_faceMask} -> {_succeeded}";
		}
	}
}
