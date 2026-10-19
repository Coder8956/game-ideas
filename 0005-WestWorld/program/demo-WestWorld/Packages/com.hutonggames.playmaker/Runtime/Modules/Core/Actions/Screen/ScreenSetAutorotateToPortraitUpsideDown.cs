
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Enables auto-rotation to portrait, upside down.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-autorotateToPortraitUpsideDown.ht" +
		"ml")]
	public sealed class ScreenSetAutorotateToPortraitUpsideDown : BaseAction
	{
		
		[Tooltip("Set Screen Autorotate To Portrait Upside Down")]
		[SerializeField]
		private BoolVar _setAutorotateToPortraitUpsideDown;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setAutorotateToPortraitUpsideDown);
		}
		
		public override void Execute()
		{
			Screen.autorotateToPortraitUpsideDown = _setAutorotateToPortraitUpsideDown.Value;
		}
		
		public override string GetSummary()
		{
			return "Set screen autorotate to portrait upside down to {_setAutorotateToPortraitUpsideDown}";
		}
	}
}
