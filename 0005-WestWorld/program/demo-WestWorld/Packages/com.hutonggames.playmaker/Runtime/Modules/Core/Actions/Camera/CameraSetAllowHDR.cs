
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("High dynamic range rendering.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-allowHDR.html")]
	public sealed class CameraSetAllowHDR : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Allow HDR")]
		[SerializeField]
		private BoolVar _setAllowHDR;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setAllowHDR);
		}
		
		public override void Execute()
		{
			_camera.Value.allowHDR = _setAllowHDR.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} allow HDR to {_setAllowHDR}";
		}
	}
}
