
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The aspect ratio (width divided by height).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-aspect.html")]
	public sealed class CameraGetAspect : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Aspect")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAspect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getAspect);
		}
		
		public override void Execute()
		{
			_getAspect.Value = _camera.Value.aspect;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} aspect -> {_getAspect}";
		}
	}
}
