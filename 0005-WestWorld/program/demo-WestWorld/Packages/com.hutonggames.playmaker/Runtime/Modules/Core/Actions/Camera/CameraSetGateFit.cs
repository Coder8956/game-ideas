
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("There are two gates for a camera, the sensor gate and the resolution gate. The ph" +
		"ysical camera sensor gate is defined by the sensorSize property, the resolution " +
		"gate is defined by the render target area.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-gateFit.html")]
	public sealed class CameraSetGateFit : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Gate Fit")]
		[SerializeField]
		private Camera_GateFitModeVar _setGateFit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setGateFit);
		}
		
		public override void Execute()
		{
			_camera.Value.gateFit = _setGateFit.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} gate fit to {_setGateFit}";
		}
	}
}
