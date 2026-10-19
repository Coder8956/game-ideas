
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Set this property to one of the values in FullScreenMode to change the display mo" +
		"de of your application.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-fullScreenMode.html")]
	public sealed class ScreenSetFullScreenMode : BaseAction
	{
		
		[Tooltip("Set Screen Full Screen Mode")]
		[SerializeField]
		private FullScreenModeVar _setFullScreenMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setFullScreenMode);
		}
		
		public override void Execute()
		{
			Screen.fullScreenMode = _setFullScreenMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set screen full screen mode to {_setFullScreenMode}";
		}
	}
}
