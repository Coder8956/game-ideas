
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Set the target display for this Camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-targetDisplay.html")]
	public sealed class CameraGetTargetDisplay : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Target Display")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getTargetDisplay;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getTargetDisplay);
		}
		
		public override void Execute()
		{
			_getTargetDisplay.Value = _camera.Value.targetDisplay;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} target display -> {_getTargetDisplay}";
		}
	}
}
