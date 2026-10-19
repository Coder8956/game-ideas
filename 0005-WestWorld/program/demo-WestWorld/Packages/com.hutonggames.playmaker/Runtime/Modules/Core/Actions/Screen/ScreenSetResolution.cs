
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Switches the screen resolution.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen.SetResolution.html")]
	public sealed class ScreenSetResolution : BaseAction
	{
		
		[Tooltip("Width.")]
		[SerializeField]
		[DefaultValue(800)]
		private IntegerVar _width;
		
		[Tooltip("Height.")]
		[SerializeField]
		[DefaultValue(600)]
		private IntegerVar _height;
		
		[Tooltip("Fullscreen Mode.")]
		[SerializeField]
		private FullScreenModeVar _fullscreenMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_width, _height, _fullscreenMode);
		}
		
		public override void Execute()
		{
			//UnityEngine.Screen.SetResolution(System.Int32, System.Int32, UnityEngine.FullScreenMode);
			Screen.SetResolution(_width.Value, _height.Value, _fullscreenMode.Value);
		}
		
		public override string GetSummary()
		{
			return "Set screen resolution {_width} {_height} {_fullscreenMode}";
		}
	}
}
