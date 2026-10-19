
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
	public sealed class CameraGetBladeCount : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Blade Count")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getBladeCount;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getBladeCount);
		}
		
		public override void Execute()
		{
			_getBladeCount.Value = _camera.Value.bladeCount;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} blade count -> {_getBladeCount}";
		}
	}
}
