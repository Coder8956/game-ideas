
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("The current width of the screen window in pixels (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-width.html")]
	public sealed class ScreenGetWidth : BaseAction
	{
		
		[Tooltip("Get Screen Width")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getWidth;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getWidth);
		}
		
		public override void Execute()
		{
			_getWidth.Value = Screen.width;
		}
		
		public override string GetSummary()
		{
			return "Get screen width -> {_getWidth}";
		}
	}
}
