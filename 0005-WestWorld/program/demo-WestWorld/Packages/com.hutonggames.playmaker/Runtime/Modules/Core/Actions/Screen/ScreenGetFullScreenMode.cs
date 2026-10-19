
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
	public sealed class ScreenGetFullScreenMode : BaseAction
	{
		
		[Tooltip("Get Screen Full Screen Mode")]
		[SerializeField]
		[WriteOnly]
		private FullScreenModeRef _getFullScreenMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getFullScreenMode);
		}
		
		public override void Execute()
		{
			_getFullScreenMode.Value = Screen.fullScreenMode;
		}
		
		public override string GetSummary()
		{
			return "Get screen full screen mode -> {_getFullScreenMode}";
		}
	}
}
