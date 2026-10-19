
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
	public sealed class CameraSetCullingMask : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Culling Mask")]
		[SerializeField]
		private LayerMaskVar _setCullingMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setCullingMask);
		}
		
		public override void Execute()
		{
			_camera.Value.cullingMask = _setCullingMask.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} culling mask to {_setCullingMask}";
		}
	}
}
