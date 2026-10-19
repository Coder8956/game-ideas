
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Converts focal length to field of view.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.FocalLengthToFieldOfView.html")]
	public sealed class CameraFocalLengthToFieldOfView : BaseAction
	{
		
		[Tooltip("Focal length in millimeters.")]
		[SerializeField]
		private FloatVar _focalLength;
		
		[Tooltip("Sensor size in millimeters. Use the sensor height to get the vertical field of view. " +
		         "Use the sensor width to get the horizontal field of view.")]
		[SerializeField]
		private FloatVar _sensorSize;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_focalLength, _sensorSize, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.FocalLengthToFieldOfView(System.Single, System.Single);
			_result.Value = Camera.FocalLengthToFieldOfView(_focalLength.Value, _sensorSize.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert focal length {_focalLength} and sensor size {_sensorSize} to FOV -> {_result}";
		}
	}
}
