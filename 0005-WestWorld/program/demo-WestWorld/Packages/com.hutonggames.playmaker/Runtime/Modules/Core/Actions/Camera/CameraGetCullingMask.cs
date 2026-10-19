
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("This is used to render parts of the Scene selectively.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-cullingMask.html")]
	public sealed class CameraGetCullingMask : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Culling Mask")]
		[SerializeField]
		[WriteOnly]
		private LayerMaskRef _getCullingMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getCullingMask);
		}
		
		public override void Execute()
		{
			_getCullingMask.Value = _camera.Value.cullingMask;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} culling mask -> {_getCullingMask}";
		}
	}
}
