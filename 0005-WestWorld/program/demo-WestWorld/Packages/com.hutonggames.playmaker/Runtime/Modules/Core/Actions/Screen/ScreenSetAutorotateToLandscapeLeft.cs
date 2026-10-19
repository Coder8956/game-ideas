
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Enables auto-rotation to landscape left.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-autorotateToLandscapeLeft.html")]
	public sealed class ScreenSetAutorotateToLandscapeLeft : BaseAction
	{
		
		[Tooltip("Set Screen Autorotate To Landscape Left")]
		[SerializeField]
		private BoolVar _setAutorotateToLandscapeLeft;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setAutorotateToLandscapeLeft);
		}
		
		public override void Execute()
		{
			Screen.autorotateToLandscapeLeft = _setAutorotateToLandscapeLeft.Value;
		}
		
		public override string GetSummary()
		{
			return "Set screen autorotate to landscape left to {_setAutorotateToLandscapeLeft}";
		}
	}
}
