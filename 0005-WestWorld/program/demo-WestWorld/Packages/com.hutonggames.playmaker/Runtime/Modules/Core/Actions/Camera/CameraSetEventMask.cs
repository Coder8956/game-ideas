
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Mask to select which layers can trigger events on the camera.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-eventMask.html")]
	public sealed class CameraSetEventMask : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Event Mask")]
		[SerializeField]
		private IntegerVar _setEventMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setEventMask);
		}
		
		public override void Execute()
		{
			_camera.Value.eventMask = _setEventMask.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} event mask to {_setEventMask}";
		}
	}
}
