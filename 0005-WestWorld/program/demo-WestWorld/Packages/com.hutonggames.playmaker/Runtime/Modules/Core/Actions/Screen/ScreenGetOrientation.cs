
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Specifies logical orientation of the screen.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-orientation.html")]
	public sealed class ScreenGetOrientation : BaseAction
	{
		
		[Tooltip("Get Screen Orientation")]
		[SerializeField]
		[WriteOnly]
		private ScreenOrientationRef _getOrientation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getOrientation);
		}
		
		public override void Execute()
		{
			_getOrientation.Value = Screen.orientation;
		}
		
		public override string GetSummary()
		{
			return "Get screen orientation -> {_getOrientation}";
		}
	}
}
