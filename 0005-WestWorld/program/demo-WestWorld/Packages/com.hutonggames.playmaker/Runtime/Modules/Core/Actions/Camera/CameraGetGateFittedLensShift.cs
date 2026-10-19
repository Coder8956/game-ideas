
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription(@"Retrieves the effective lens offset of the camera, including GateFit. Fitting the sensor gate and the resolution gate has an impact on the final obliqueness of the projection. If the sensor gate aspect ratio is the same as the resolution gate aspect ratio, then this method returns the same value as the lenshift property. If the camera is not in physical mode, then this methods returns Vector2.zero.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.GetGateFittedLensShift.html")]
	public sealed class CameraGetGateFittedLensShift : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Store the result in Vector2 variable.")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.GetGateFittedLensShift();
			_result.Value = _camera.Value.GetGateFittedLensShift();
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} gate fitted lens shift -> {_result}";
		}
	}
}
