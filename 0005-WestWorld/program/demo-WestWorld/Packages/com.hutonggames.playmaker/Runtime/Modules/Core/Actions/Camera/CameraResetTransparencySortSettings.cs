
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Camera)]
	[ActionDescription("Resets this Camera\'s transparency sort settings to the default. Default transpare" +
		"ncy settings are taken from GraphicsSettings instead of directly from this Camer" +
		"a.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Camera.ResetTransparencySortSettings.htm" +
		"l")]
	public sealed class CameraResetTransparencySortSettings : BaseAction
	{
		
		[Tooltip("The Camera.")]
		[SerializeField]
		private CameraVar _camera;
		
		public override bool CanExecute()
		{
			return CheckParameters(_camera);
		}
		
		public override void Execute()
		{
			//UnityEngine.Camera.ResetTransparencySortSettings();
			_camera.Value.ResetTransparencySortSettings();
		}
		
		public override string GetSummary()
		{
			return "Reset {_camera} transparency sort settings";
		}
	}
}
