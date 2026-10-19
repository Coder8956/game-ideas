
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Returns the safe area of the screen in pixels (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-safeArea.html")]
	public sealed class ScreenGetSafeArea : BaseAction
	{
		
		[Tooltip("Get Screen Safe Area")]
		[SerializeField]
		[WriteOnly]
		private RectRef _getSafeArea;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getSafeArea);
		}
		
		public override void Execute()
		{
			_getSafeArea.Value = Screen.safeArea;
		}
		
		public override string GetSummary()
		{
			return "Get screen safe area -> {_getSafeArea}";
		}
	}
}
