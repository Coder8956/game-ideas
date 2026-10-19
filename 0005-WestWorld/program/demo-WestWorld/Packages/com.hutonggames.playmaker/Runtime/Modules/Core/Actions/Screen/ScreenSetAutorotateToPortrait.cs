
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Enables auto-rotation to portrait.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-autorotateToPortrait.html")]
	public sealed class ScreenSetAutorotateToPortrait : BaseAction
	{
		
		[Tooltip("Set Screen Autorotate To Portrait")]
		[SerializeField]
		private BoolVar _setAutorotateToPortrait;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setAutorotateToPortrait);
		}
		
		public override void Execute()
		{
			Screen.autorotateToPortrait = _setAutorotateToPortrait.Value;
		}
		
		public override string GetSummary()
		{
			return "Set screen autorotate to portrait to {_setAutorotateToPortrait}";
		}
	}
}
