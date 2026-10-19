
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The size of the camera sensor, expressed in millimeters.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-sensorSize.html")]
	public sealed class CameraSetSensorSize : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Sensor Size")]
		[SerializeField]
		private Vector2Var _setSensorSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setSensorSize);
		}
		
		public override void Execute()
		{
			_camera.Value.sensorSize = _setSensorSize.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} sensor size to {_setSensorSize}";
		}
	}
}
