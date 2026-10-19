
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
	public sealed class CameraSetAspect : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Aspect")]
		[SerializeField]
		private FloatVar _setAspect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setAspect);
		}
		
		public override void Execute()
		{
			_camera.Value.aspect = _setAspect.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} aspect to {_setAspect}";
		}
	}
}
