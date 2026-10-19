
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Destination render texture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-targetTexture.html")]
	public sealed class CameraGetTargetTexture : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Target Texture")]
		[SerializeField]
		[WriteOnly]
		private RenderTextureRef _getTargetTexture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getTargetTexture);
		}
		
		public override void Execute()
		{
			_getTargetTexture.Value = _camera.Value.targetTexture;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} target texture -> {_getTargetTexture}";
		}
	}
}
