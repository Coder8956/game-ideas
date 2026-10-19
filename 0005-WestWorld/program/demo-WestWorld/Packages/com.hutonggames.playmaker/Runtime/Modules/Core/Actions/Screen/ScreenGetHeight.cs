
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("The current height of the screen window in pixels (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-height.html")]
	public sealed class ScreenGetHeight : BaseAction
	{
		
		[Tooltip("Get Screen Height")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getHeight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getHeight);
		}
		
		public override void Execute()
		{
			_getHeight.Value = Screen.height;
		}
		
		public override string GetSummary()
		{
			return "Get screen height -> {_getHeight}";
		}
	}
}
