
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Distance to a point where virtual eyes converge.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-stereoConvergence.html")]
	public sealed class CameraSetStereoConvergence : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Stereo Convergence")]
		[SerializeField]
		private FloatVar _setStereoConvergence;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setStereoConvergence);
		}
		
		public override void Execute()
		{
			_camera.Value.stereoConvergence = _setStereoConvergence.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} stereo convergence to {_setStereoConvergence}";
		}
	}
}
