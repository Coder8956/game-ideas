
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("MSAA rendering.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-allowMSAA.html")]
	public sealed class CameraSetAllowMSAA : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Allow MSAA")]
		[SerializeField]
		private BoolVar _setAllowMSAA;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setAllowMSAA);
		}
		
		public override void Execute()
		{
			_camera.Value.allowMSAA = _setAllowMSAA.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} allow MSAA to {_setAllowMSAA}";
		}
	}
}
