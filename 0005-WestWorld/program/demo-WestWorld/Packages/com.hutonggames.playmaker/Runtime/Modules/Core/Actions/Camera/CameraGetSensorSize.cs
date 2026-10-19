
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The size of the camera sensor, expressed in millimeters.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-sensorSize.html")]
	public sealed class CameraGetSensorSize : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Sensor Size")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getSensorSize;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getSensorSize);
		}
		
		public override void Execute()
		{
			_getSensorSize.Value = _camera.Value.sensorSize;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} sensor size -> {_getSensorSize}";
		}
	}
}
