
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Should the jittered matrix be used for transparency rendering?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-useJitteredProjectionMatrixForTra" +
		"nsparentRendering.html")]
	public sealed class CameraSetUseJitteredProjectionMatrixForTransparentRendering : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Use Jittered Projection Matrix For Transparent Rendering")]
		[SerializeField]
		private BoolVar _setUseJitteredProjectionMatrixForTransparentRendering;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setUseJitteredProjectionMatrixForTransparentRendering);
		}
		
		public override void Execute()
		{
			_camera.Value.useJitteredProjectionMatrixForTransparentRendering = _setUseJitteredProjectionMatrixForTransparentRendering.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} use jittered projection matrix for transparent rendering to {_setUseJitteredProjectionMatrixForTransparentRendering}";
		}
	}
}
