
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Should the camera clear the stencil buffer after the deferred light pass?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-clearStencilAfterLightingPass.htm" +
		"l")]
	public sealed class CameraGetClearStencilAfterLightingPass : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Clear Stencil After Lighting Pass")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getClearStencilAfterLightingPass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getClearStencilAfterLightingPass);
		}
		
		public override void Execute()
		{
			_getClearStencilAfterLightingPass.Value = _camera.Value.clearStencilAfterLightingPass;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} clear stencil after lighting pass -> {_getClearStencilAfterLightingPass}";
		}
	}
}
