
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The lens offset of the camera. The lens shift is relative to the sensor size. For" +
		" example, a lens shift of 0.5 offsets the sensor by half its horizontal size.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-lensShift.html")]
	public sealed class CameraGetLensShift : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Lens Shift")]
		[SerializeField]
		[WriteOnly]
		private Vector2Ref _getLensShift;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getLensShift);
		}
		
		public override void Execute()
		{
			_getLensShift.Value = _camera.Value.lensShift;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} lens shift -> {_getLensShift}";
		}
	}
}
