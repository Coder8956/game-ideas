
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("The color with which the screen will be cleared.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-backgroundColor.html")]
	public sealed class CameraGetBackgroundColor : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Background Color")]
		[SerializeField]
		[WriteOnly]
		private ColorRef _getBackgroundColor;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getBackgroundColor);
		}
		
		public override void Execute()
		{
			_getBackgroundColor.Value = _camera.Value.backgroundColor;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} background color -> {_getBackgroundColor}";
		}
	}
}
