
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Transparent object sorting mode.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-transparencySortMode.html")]
	public sealed class CameraGetTransparencySortMode : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Get Camera Transparency Sort Mode")]
		[SerializeField]
		[WriteOnly]
		private TransparencySortModeRef _getTransparencySortMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _getTransparencySortMode);
		}
		
		public override void Execute()
		{
			_getTransparencySortMode.Value = _camera.Value.transparencySortMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_camera} transparency sort mode -> {_getTransparencySortMode}";
		}
	}
}
