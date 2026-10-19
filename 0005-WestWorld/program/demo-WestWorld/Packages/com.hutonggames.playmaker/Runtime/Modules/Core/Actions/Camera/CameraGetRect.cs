
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Where on the screen is the camera rendered in normalized coordinates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-rect.html")]
	public sealed class CameraGetRect : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Rect")]
		[SerializeField]
		[WriteOnly]
		private RectRef _getRect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getRect);
		}
		
		public override void Execute()
		{
			_getRect.Value = _camera.Value.rect;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} rect -> {_getRect}";
		}
	}
}
