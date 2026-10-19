
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ConvertibleGroup("CameraRenderToCubemap")]
	[ActionDescription("Render into a static cubemap from this camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.RenderToCubemap.html")]
	public sealed class CameraRenderToCubemap3 : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("The cube map to render to.")]
		[SerializeField]
		private RenderTextureVar _cubemap;
		
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
			//UnityEngine.Camera.RenderToCubemap(UnityEngine.RenderTexture);
			_succeeded.Value = _camera.Value.RenderToCubemap(_cubemap.Value);
		}
		
		public override string GetSummary()
		{
			return "Render {_camera} to cubemap {_cubemap} -> {_succeeded}";
		}
	}
}
