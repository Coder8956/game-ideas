
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The camera barrel clipping. To use this property, enable UsePhysicalProperties.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-barrelClipping.html")]
	public sealed class CameraGetBarrelClipping : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Barrel Clipping")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getBarrelClipping;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getBarrelClipping);
		}
		
		public override void Execute()
		{
			_getBarrelClipping.Value = _camera.Value.barrelClipping;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} barrel clipping -> {_getBarrelClipping}";
		}
	}
}
