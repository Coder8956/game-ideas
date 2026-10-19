
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Enables auto-rotation to landscape left.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-autorotateToLandscapeLeft.html")]
	public sealed class ScreenGetAutorotateToLandscapeLeft : BaseAction
	{
		
		[Tooltip("Get Screen Autorotate To Landscape Left")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutorotateToLandscapeLeft;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getAutorotateToLandscapeLeft);
		}
		
		public override void Execute()
		{
			_getAutorotateToLandscapeLeft.Value = Screen.autorotateToLandscapeLeft;
		}
		
		public override string GetSummary()
		{
			return "Get screen autorotate to landscape left -> {_getAutorotateToLandscapeLeft}";
		}
	}
}
