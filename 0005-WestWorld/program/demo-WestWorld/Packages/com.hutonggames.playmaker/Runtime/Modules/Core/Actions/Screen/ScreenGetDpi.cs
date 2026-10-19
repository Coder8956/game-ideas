
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("The current DPI of the screen / device (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-dpi.html")]
	public sealed class ScreenGetDpi : BaseAction
	{
		
		[Tooltip("Get Screen Dpi")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDpi;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getDpi);
		}
		
		public override void Execute()
		{
			_getDpi.Value = Screen.dpi;
		}
		
		public override string GetSummary()
		{
			return "Get screen DPI -> {_getDpi}";
		}
	}
}
