
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
	public sealed class CameraSetDepth : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Depth")]
		[SerializeField]
		private FloatVar _setDepth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setDepth);
		}
		
		public override void Execute()
		{
			_camera.Value.depth = _setDepth.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} depth to {_setDepth}";
		}
	}
}
