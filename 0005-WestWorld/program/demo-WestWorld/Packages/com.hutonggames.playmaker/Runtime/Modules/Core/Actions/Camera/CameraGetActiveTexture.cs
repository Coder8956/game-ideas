
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Gets the temporary RenderTexture target for this Camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-activeTexture.html")]
	public sealed class CameraGetActiveTexture : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Active Texture")]
		[SerializeField]
		[WriteOnly]
		private RenderTextureRef _getActiveTexture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getActiveTexture);
		}
		
		public override void Execute()
		{
			_getActiveTexture.Value = _camera.Value.activeTexture;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} active texture -> {_getActiveTexture}";
		}
	}
}
