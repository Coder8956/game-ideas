
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Enables full-screen mode for the application.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-fullScreen.html")]
	public sealed class ScreenSetFullScreen : BaseAction
	{
		
		[Tooltip("Set Screen Full Screen")]
		[SerializeField]
		private BoolVar _setFullScreen;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setFullScreen);
		}
		
		public override void Execute()
		{
			Screen.fullScreen = _setFullScreen.Value;
		}
		
		public override string GetSummary()
		{
			return "Set screen full screen to {_setFullScreen}";
		}
	}
}
