
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("How and if camera generates a depth texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-depthTextureMode.html")]
	public sealed class CameraGetDepthTextureMode : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Depth Texture Mode")]
		[SerializeField]
		[WriteOnly]
		private DepthTextureModeRef _getDepthTextureMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getDepthTextureMode);
		}
		
		public override void Execute()
		{
			_getDepthTextureMode.Value = _camera.Value.depthTextureMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} depth texture mode -> {_getDepthTextureMode}";
		}
	}
}
