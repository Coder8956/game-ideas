
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription(@"Retrieves the effective vertical field of view of the camera, including GateFit. Fitting the sensor gate and the resolution gate has an impact on the final field of view. If the sensor gate aspect ratio is the same as the resolution gate aspect ratio or if the camera is not in physical mode, then this method returns the same value as the fieldofview property.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.GetGateFittedFieldOfView.html")]
	public sealed class CameraGetGateFittedFieldOfView : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Store the result in Float variable.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _result;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _result);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.GetGateFittedFieldOfView();
			_result.Value = _camera.Value.GetGateFittedFieldOfView();
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} gate fitted FOV -> {_result}";
		}
	}
}
