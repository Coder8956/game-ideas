
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
	public sealed class CameraSetForceIntoRenderTexture : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Force Into Render Texture")]
		[SerializeField]
		private BoolVar _setForceIntoRenderTexture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setForceIntoRenderTexture);
		}
		
		public override void Execute()
		{
			_camera.Value.forceIntoRenderTexture = _setForceIntoRenderTexture.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} force into render texture to {_setForceIntoRenderTexture}";
		}
	}
}
