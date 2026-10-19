
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
	public sealed class CameraSetTargetDisplay : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Target Display")]
		[SerializeField]
		private IntegerVar _setTargetDisplay;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setTargetDisplay);
		}
		
		public override void Execute()
		{
			_camera.Value.targetDisplay = _setTargetDisplay.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} target display to {_setTargetDisplay}";
		}
	}
}
