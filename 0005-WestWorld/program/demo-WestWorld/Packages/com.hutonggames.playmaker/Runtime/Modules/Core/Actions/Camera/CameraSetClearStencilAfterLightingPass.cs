
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
	public sealed class CameraSetClearStencilAfterLightingPass : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Clear Stencil After Lighting Pass")]
		[SerializeField]
		private BoolVar _setClearStencilAfterLightingPass;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setClearStencilAfterLightingPass);
		}
		
		public override void Execute()
		{
			_camera.Value.clearStencilAfterLightingPass = _setClearStencilAfterLightingPass.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} clear stencil after lighting pass to {_setClearStencilAfterLightingPass}";
		}
	}
}
