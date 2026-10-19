
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
	public sealed class CameraGetStereoConvergence : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Stereo Convergence")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getStereoConvergence;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getStereoConvergence);
		}
		
		public override void Execute()
		{
			_getStereoConvergence.Value = _camera.Value.stereoConvergence;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} stereo convergence -> {_getStereoConvergence}";
		}
	}
}
