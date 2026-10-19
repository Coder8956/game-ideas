
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
	public sealed class CameraGetUseJitteredProjectionMatrixForTransparentRendering : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Use Jittered Projection Matrix For Transparent Rendering")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUseJitteredProjectionMatrixForTransparentRendering;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getUseJitteredProjectionMatrixForTransparentRendering);
		}
		
		public override void Execute()
		{
			_getUseJitteredProjectionMatrixForTransparentRendering.Value = _camera.Value.useJitteredProjectionMatrixForTransparentRendering;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} use jittered projection matrix for transparent rendering -> {_getUseJitteredProjectionMatrixForTransparentRendering}";
		}
	}
}
