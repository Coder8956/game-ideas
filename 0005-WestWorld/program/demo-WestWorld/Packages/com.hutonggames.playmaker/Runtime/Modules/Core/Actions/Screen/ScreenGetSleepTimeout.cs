
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
	public sealed class ScreenGetSleepTimeout : BaseAction
	{
		
		[Tooltip("Get Screen Sleep Timeout")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getSleepTimeout;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getSleepTimeout);
		}
		
		public override void Execute()
		{
			_getSleepTimeout.Value = Screen.sleepTimeout;
		}
		
		public override string GetSummary()
		{
			return "Get screen sleep timeout -> {_getSleepTimeout}";
		}
	}
}
