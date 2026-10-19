
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Returns a list of screen areas that are not functional for displaying content (Re" +
		"ad Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-cutouts.html")]
	public sealed class ScreenGetCutouts : BaseAction
	{
		
		[Tooltip("Get Screen Cutouts")]
		[SerializeField]
		[WriteOnly]
		private RectListRef _getCutouts;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getCutouts);
		}
		
		public override void Execute()
		{
			_getCutouts.Values = Screen.cutouts;
		}
		
		public override string GetSummary()
		{
			return "Get screen cutouts -> {_getCutouts}";
		}
	}
}
