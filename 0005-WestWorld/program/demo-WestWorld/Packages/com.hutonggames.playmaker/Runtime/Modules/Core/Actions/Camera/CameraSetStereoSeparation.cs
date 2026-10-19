
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
	public sealed class CameraSetStereoSeparation : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Stereo Separation")]
		[SerializeField]
		private FloatVar _setStereoSeparation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setStereoSeparation);
		}
		
		public override void Execute()
		{
			_camera.Value.stereoSeparation = _setStereoSeparation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} stereo separation to {_setStereoSeparation}";
		}
	}
}
