
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
	public sealed class CameraGetEventMask : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Event Mask")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getEventMask;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getEventMask);
		}
		
		public override void Execute()
		{
			_getEventMask.Value = _camera.Value.eventMask;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} eventMask -> {_getEventMask}";
		}
	}
}
