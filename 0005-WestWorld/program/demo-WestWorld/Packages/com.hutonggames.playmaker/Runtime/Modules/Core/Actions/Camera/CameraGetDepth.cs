
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Camera\'s depth in the camera rendering order.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-depth.html")]
	public sealed class CameraGetDepth : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Depth")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getDepth);
		}
		
		public override void Execute()
		{
			_getDepth.Value = _camera.Value.depth;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} depth -> {_getDepth}";
		}
	}
}
