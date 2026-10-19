
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Stereoscopic rendering.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-stereoEnabled.html")]
	public sealed class CameraGetStereoEnabled : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Stereo Enabled")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getStereoEnabled;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getStereoEnabled);
		}
		
		public override void Execute()
		{
			_getStereoEnabled.Value = _camera.Value.stereoEnabled;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} stereo enabled -> {_getStereoEnabled}";
		}
	}
}
