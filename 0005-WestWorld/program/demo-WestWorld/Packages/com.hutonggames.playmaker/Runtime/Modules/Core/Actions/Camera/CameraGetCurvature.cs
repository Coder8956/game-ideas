
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The curvature of the blades. To use this property, enable UsePhysicalProperties.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-curvature.html")]
	public sealed class CameraGetCurvature : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Curvature")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getCurvature;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getCurvature);
		}
		
		public override void Execute()
		{
			_getCurvature.Value = _camera.Value.curvature;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} curvature -> {_getCurvature}";
		}
	}
}
