
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Specifies logical orientation of the screen.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-orientation.html")]
	public sealed class ScreenSetOrientation : BaseAction
	{
		
		[Tooltip("Set Screen Orientation")]
		[SerializeField]
		private ScreenOrientationVar _setOrientation;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setOrientation);
		}
		
		public override void Execute()
		{
			Screen.orientation = _setOrientation.Value;
		}
		
		public override string GetSummary()
		{
			return "Set screen orientation to {_setOrientation}";
		}
	}
}
