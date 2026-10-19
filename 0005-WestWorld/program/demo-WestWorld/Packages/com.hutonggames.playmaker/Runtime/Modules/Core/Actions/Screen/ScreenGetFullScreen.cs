
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Enables full-screen mode for the application.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-fullScreen.html")]
	public sealed class ScreenGetFullScreen : BaseAction
	{
		
		[Tooltip("Get Screen Full Screen")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getFullScreen;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getFullScreen);
		}
		
		public override void Execute()
		{
			_getFullScreen.Value = Screen.fullScreen;
		}
		
		public override string GetSummary()
		{
			return "Get screen full screen -> {_getFullScreen}";
		}
	}
}
