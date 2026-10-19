
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Where on the screen is the camera rendered in pixel coordinates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-pixelRect.html")]
	public sealed class CameraGetPixelRect : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Pixel Rect")]
		[SerializeField]
		[WriteOnly]
		private RectRef _getPixelRect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getPixelRect);
		}
		
		public override void Execute()
		{
			_getPixelRect.Value = _camera.Value.pixelRect;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} pixel rect -> {_getPixelRect}";
		}
	}
}
