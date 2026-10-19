
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
	public sealed class CameraSetBarrelClipping : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Barrel Clipping")]
		[SerializeField]
		private FloatVar _setBarrelClipping;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setBarrelClipping);
		}
		
		public override void Execute()
		{
			_camera.Value.barrelClipping = _setBarrelClipping.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} barrel clipping to {_setBarrelClipping}";
		}
	}
}
