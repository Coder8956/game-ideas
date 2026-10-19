
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The distance between the virtual eyes. Use this to query or set the current eye s" +
		"eparation. Note that most VR devices provide this value, in which case setting t" +
		"he value will have no effect.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-stereoSeparation.html")]
	public sealed class CameraGetStereoSeparation : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Stereo Separation")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getStereoSeparation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getStereoSeparation);
		}
		
		public override void Execute()
		{
			_getStereoSeparation.Value = _camera.Value.stereoSeparation;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} stereo separation -> {_getStereoSeparation}";
		}
	}
}
