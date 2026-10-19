
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
	public sealed class CameraGetAperture : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Aperture")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getAperture;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getAperture);
		}
		
		public override void Execute()
		{
			_getAperture.Value = _camera.Value.aperture;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} aperture -> {_getAperture}";
		}
	}
}
