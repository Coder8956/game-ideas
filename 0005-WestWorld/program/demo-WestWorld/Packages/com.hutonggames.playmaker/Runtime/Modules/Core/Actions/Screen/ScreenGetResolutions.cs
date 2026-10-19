
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Returns all full-screen resolutions that the monitor supports (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-resolutions.html")]
	public sealed class ScreenGetResolutions : BaseAction
	{
		
		[Tooltip("Get Screen Resolutions")]
		[SerializeField]
		[WriteOnly]
		private ResolutionListRef _getResolutions;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getResolutions);
		}
		
		public override void Execute()
		{
			_getResolutions.Values = Screen.resolutions;
		}
		
		public override string GetSummary()
		{
			return "Get screen resolutions -> {_getResolutions}";
		}
	}
}
