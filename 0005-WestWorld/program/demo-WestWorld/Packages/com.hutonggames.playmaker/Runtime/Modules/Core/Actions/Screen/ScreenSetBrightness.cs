
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("Indicates the current brightness of the screen.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-brightness.html")]
	public sealed class ScreenSetBrightness : BaseAction
	{
		
		[Tooltip("Set Screen Brightness")]
		[SerializeField]
		private FloatVar _setBrightness;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setBrightness);
		}
		
		public override void Execute()
		{
			Screen.brightness = _setBrightness.Value;
		}
		
		public override string GetSummary()
		{
			return "Set screen brightness to {_setBrightness}";
		}
	}
}
