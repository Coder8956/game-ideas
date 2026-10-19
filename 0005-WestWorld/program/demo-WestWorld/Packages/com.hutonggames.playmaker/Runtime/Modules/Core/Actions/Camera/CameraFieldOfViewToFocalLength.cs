
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Converts field of view to focal length. " +
	                   "Use either sensor height and vertical field of view or sensor width and horizontal field of view.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.FieldOfViewToFocalLength.html")]
	public sealed class CameraFieldOfViewToFocalLength : BaseAction
	{
		
		[Tooltip("field of view in degrees.")]
		[SerializeField]
		private FloatVar _fieldOfView;
		
		[Tooltip("Sensor size in millimeters.")]
		[SerializeField]
		private FloatVar _sensorSize;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_fieldOfView, _sensorSize, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.FieldOfViewToFocalLength(System.Single, System.Single);
			_result.Value = Camera.FieldOfViewToFocalLength(_fieldOfView.Value, _sensorSize.Value);
		}
		
		public override string GetSummary()
		{
			return "Convert FOV {_fieldOfView} and sensor size {_sensorSize} to focal length -> {_result}";
		}
	}
}
