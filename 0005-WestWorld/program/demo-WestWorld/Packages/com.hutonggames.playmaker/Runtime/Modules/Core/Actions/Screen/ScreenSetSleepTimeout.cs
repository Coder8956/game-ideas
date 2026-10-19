
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.Screen)]
	[ActionDescription("A power saving setting, allowing the screen to dim some time after the last activ" +
		"e user interaction.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Screen-sleepTimeout.html")]
	public sealed class ScreenSetSleepTimeout : BaseAction
	{
		
		[Tooltip("Set Screen Sleep Timeout")]
		[SerializeField]
		private IntegerVar _setSleepTimeout;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setSleepTimeout);
		}
		
		public override void Execute()
		{
			Screen.sleepTimeout = _setSleepTimeout.Value;
		}
		
		public override string GetSummary()
		{
			return "Set screen sleep timeout to {_setSleepTimeout}";
		}
	}
}
