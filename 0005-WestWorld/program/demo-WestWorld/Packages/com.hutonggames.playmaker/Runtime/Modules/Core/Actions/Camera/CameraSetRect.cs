
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Where on the screen is the camera rendered in normalized coordinates.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-rect.html")]
	public sealed class CameraSetRect : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Rect")]
		[SerializeField]
		private RectVar _setRect;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setRect);
		}
		
		public override void Execute()
		{
			_camera.Value.rect = _setRect.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} rect to {_setRect}";
		}
	}
}
