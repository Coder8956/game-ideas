
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Should camera rendering be forced into a RenderTexture.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-forceIntoRenderTexture.html")]
	public sealed class CameraGetForceIntoRenderTexture : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Force Into Render Texture")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getForceIntoRenderTexture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getForceIntoRenderTexture);
		}
		
		public override void Execute()
		{
			_getForceIntoRenderTexture.Value = _camera.Value.forceIntoRenderTexture;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} force into render texture -> {_getForceIntoRenderTexture}";
		}
	}
}
