
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Dynamic Resolution Scaling.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-allowDynamicResolution.html")]
	public sealed class CameraSetAllowDynamicResolution : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Allow Dynamic Resolution")]
		[SerializeField]
		private BoolVar _setAllowDynamicResolution;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setAllowDynamicResolution);
		}
		
		public override void Execute()
		{
			_camera.Value.allowDynamicResolution = _setAllowDynamicResolution.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} allow dynamic resolution to {_setAllowDynamicResolution}";
		}
	}
}
