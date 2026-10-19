
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Transparent object sorting mode.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera-transparencySortMode.html")]
	public sealed class CameraSetTransparencySortMode : BaseAction
	{
		
		[Tooltip("The Camera")]
		[SerializeField]
		private CameraVar _camera;
		
		[Tooltip("Set Camera Transparency Sort Mode")]
		[SerializeField]
		private TransparencySortModeVar _setTransparencySortMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera, _setTransparencySortMode);
		}
		
		public override void Execute()
		{
			_camera.Value.transparencySortMode = _setTransparencySortMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_camera} transparency sort mode to {_setTransparencySortMode}";
		}
	}
}
