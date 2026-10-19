
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The curvature of the blades. To use this property, enable UsePhysicalProperties.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-curvature.html")]
	public sealed class CameraSetCurvature : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Curvature")]
		[SerializeField]
		private Vector2Var _setCurvature;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setCurvature);
		}
		
		public override void Execute()
		{
			_camera.Value.curvature = _setCurvature.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} curvature to {_setCurvature}";
		}
	}
}
