
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
	public sealed class ScreenGetAutorotateToPortraitUpsideDown : BaseAction
	{
		
		[Tooltip("Get Screen Autorotate To Portrait Upside Down")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutorotateToPortraitUpsideDown;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getAutorotateToPortraitUpsideDown);
		}
		
		public override void Execute()
		{
			_getAutorotateToPortraitUpsideDown.Value = Screen.autorotateToPortraitUpsideDown;
		}
		
		public override string GetSummary()
		{
			return "Get screen autorotate to portrait upside down -> {_getAutorotateToPortraitUpsideDown}";
		}
	}
}
