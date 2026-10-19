
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
	public sealed class CameraGetIso : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Iso")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getIso;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getIso);
		}
		
		public override void Execute()
		{
			_getIso.Value = _camera.Value.iso;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} iso -> {_getIso}";
		}
	}
}
