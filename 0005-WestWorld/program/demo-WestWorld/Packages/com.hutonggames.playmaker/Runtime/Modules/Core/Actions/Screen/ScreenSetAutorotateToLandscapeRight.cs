
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Enables auto-rotation to landscape right.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-autorotateToLandscapeRight.html")]
	public sealed class ScreenSetAutorotateToLandscapeRight : BaseAction
	{
		
		[Tooltip("Set Screen Autorotate To Landscape Right")]
		[SerializeField]
		private BoolVar _setAutorotateToLandscapeRight;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setAutorotateToLandscapeRight);
		}
		
		public override void Execute()
		{
			Screen.autorotateToLandscapeRight = _setAutorotateToLandscapeRight.Value;
		}
		
		public override string GetSummary()
		{
			return "Set screen autorotate to landscape right to {_setAutorotateToLandscapeRight}";
		}
	}
}
