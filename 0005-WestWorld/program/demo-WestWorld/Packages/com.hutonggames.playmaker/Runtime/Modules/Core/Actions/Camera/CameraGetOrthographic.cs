
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Is the camera orthographic (true) or perspective (false)?")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-orthographic.html")]
	public sealed class CameraGetOrthographic : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Orthographic")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getOrthographic;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getOrthographic);
		}
		
		public override void Execute()
		{
			_getOrthographic.Value = _camera.Value.orthographic;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} orthographic -> {_getOrthographic}";
		}
	}
}
