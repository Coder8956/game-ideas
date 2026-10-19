
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
	public sealed class CameraSetLensShift : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Lens Shift")]
		[SerializeField]
		private Vector2Var _setLensShift;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setLensShift);
		}
		
		public override void Execute()
		{
			_camera.Value.lensShift = _setLensShift.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} lens shift to {_setLensShift}";
		}
	}
}
