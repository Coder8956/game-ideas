
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The camera aperture. To use this property, enable UsePhysicalProperties.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-aperture.html")]
	public sealed class CameraSetAperture : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Aperture")]
		[SerializeField]
		private FloatVar _setAperture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setAperture);
		}
		
		public override void Execute()
		{
			_camera.Value.aperture = _setAperture.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} aperture to {_setAperture}";
		}
	}
}
