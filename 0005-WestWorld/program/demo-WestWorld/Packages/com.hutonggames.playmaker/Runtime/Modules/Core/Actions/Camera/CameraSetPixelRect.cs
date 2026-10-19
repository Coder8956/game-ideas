
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Where on the screen is the camera rendered in pixel coordinates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-pixelRect.html")]
	public sealed class CameraSetPixelRect : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Pixel Rect")]
		[SerializeField]
		private RectVar _setPixelRect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setPixelRect);
		}
		
		public override void Execute()
		{
			_camera.Value.pixelRect = _setPixelRect.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} pixel rect to {_setPixelRect}";
		}
	}
}
