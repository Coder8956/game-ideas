
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
	public sealed class CameraSetUsePhysicalProperties : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Use Physical Properties")]
		[SerializeField]
		private BoolVar _setUsePhysicalProperties;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setUsePhysicalProperties);
		}
		
		public override void Execute()
		{
			_camera.Value.usePhysicalProperties = _setUsePhysicalProperties.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} use physical properties to {_setUsePhysicalProperties}";
		}
	}
}
