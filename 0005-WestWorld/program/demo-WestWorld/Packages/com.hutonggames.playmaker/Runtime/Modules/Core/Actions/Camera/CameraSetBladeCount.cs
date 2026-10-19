
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The blade count in the lens of the camera. To use this property, enable UsePhysic" +
		"alProperties.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-bladeCount.html")]
	public sealed class CameraSetBladeCount : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Blade Count")]
		[SerializeField]
		private IntegerVar _setBladeCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setBladeCount);
		}
		
		public override void Execute()
		{
			_camera.Value.bladeCount = _setBladeCount.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} blade count to {_setBladeCount}";
		}
	}
}
