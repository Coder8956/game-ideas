
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("The position of the top left corner of the main window relative to the top left c" +
		"orner of the display.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-mainWindowPosition.html")]
	public sealed class ScreenGetMainWindowPosition : BaseAction
	{
		
		[Tooltip("Get Screen Main Window Position")]
		[SerializeField]
		[WriteOnly]
		private Vector2IntRef _getMainWindowPosition;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getMainWindowPosition);
		}
		
		public override void Execute()
		{
			_getMainWindowPosition.Value = Screen.mainWindowPosition;
		}
		
		public override string GetSummary()
		{
			return "Get screen main window position -> {_getMainWindowPosition}";
		}
	}
}
