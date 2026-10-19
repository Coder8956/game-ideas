
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Enables auto-rotation to portrait.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-autorotateToPortrait.html")]
	public sealed class ScreenGetAutorotateToPortrait : BaseAction
	{
		
		[Tooltip("Get Screen Autorotate To Portrait")]
		[SerializeField]
		[WriteOnly]
		private BoolRef _getAutorotateToPortrait;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getAutorotateToPortrait);
		}
		
		public override void Execute()
		{
			_getAutorotateToPortrait.Value = Screen.autorotateToPortrait;
		}
		
		public override string GetSummary()
		{
			return "Get screen autorotate to portrait -> {_getAutorotateToPortrait}";
		}
	}
}
