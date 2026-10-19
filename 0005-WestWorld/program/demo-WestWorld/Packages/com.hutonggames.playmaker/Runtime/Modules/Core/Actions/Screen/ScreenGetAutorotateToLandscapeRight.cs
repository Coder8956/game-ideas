
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Enables auto-rotation to landscape right.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-autorotateToLandscapeRight.html")]
	public sealed class ScreenGetAutorotateToLandscapeRight : BaseAction
	{
		
		[Tooltip("Get Screen Autorotate To Landscape Right")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutorotateToLandscapeRight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getAutorotateToLandscapeRight);
		}
		
		public override void Execute()
		{
			_getAutorotateToLandscapeRight.Value = Screen.autorotateToLandscapeRight;
		}
		
		public override string GetSummary()
		{
			return "Get screen autorotate to landscape right -> {_getAutorotateToLandscapeRight}";
		}
	}
}
