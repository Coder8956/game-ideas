
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The sensor sensitivity of the camera. To use this property, enable UsePhysicalPro" +
		"perties.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-iso.html")]
	public sealed class CameraSetIso : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Iso")]
		[SerializeField]
		private IntegerVar _setIso;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setIso);
		}
		
		public override void Execute()
		{
			_camera.Value.iso = _setIso.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} iso to {_setIso}";
		}
	}
}
