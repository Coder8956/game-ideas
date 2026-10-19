
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
	public sealed class CameraGetGateFit : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Gate Fit")]
		[SerializeField]
		[WriteOnly]
		private Camera_GateFitModeRef _getGateFit;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getGateFit);
		}
		
		public override void Execute()
		{
			_getGateFit.Value = _camera.Value.gateFit;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} gate fit -> {_getGateFit}";
		}
	}
}
