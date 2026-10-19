
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("How and if camera generates a depth texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-depthTextureMode.html")]
	public sealed class CameraSetDepthTextureMode : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Depth Texture Mode")]
		[SerializeField]
		private DepthTextureModeVar _setDepthTextureMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setDepthTextureMode);
		}
		
		public override void Execute()
		{
			_camera.Value.depthTextureMode = _setDepthTextureMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} depth texture mode to {_setDepthTextureMode}";
		}
	}
}
