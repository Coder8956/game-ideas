
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Enable usePhysicalProperties to use physical camera properties to compute the fie" +
		"ld of view and the frustum.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-usePhysicalProperties.html")]
	public sealed class CameraGetUsePhysicalProperties : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Use Physical Properties")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getUsePhysicalProperties;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getUsePhysicalProperties);
		}
		
		public override void Execute()
		{
			_getUsePhysicalProperties.Value = _camera.Value.usePhysicalProperties;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} use physical properties -> {_getUsePhysicalProperties}";
		}
	}
}
