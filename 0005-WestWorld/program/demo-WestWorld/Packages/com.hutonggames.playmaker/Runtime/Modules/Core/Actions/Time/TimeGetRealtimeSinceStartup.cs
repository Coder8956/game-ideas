
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The real time in seconds since the game started (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-realtimeSinceStartup.html")]
	public sealed class TimeGetRealtimeSinceStartup : BaseAction
	{
		
		[Tooltip("Get Time Realtime Since Startup")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getRealtimeSinceStartup;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getRealtimeSinceStartup);
		}
		
		public override void Execute()
		{
			_getRealtimeSinceStartup.Value = TimeHelper.RealtimeSinceStartup;
		}
		
		public override string GetSummary()
		{
			return "Get realtime since startup -> {_getRealtimeSinceStartup}";
		}
	}
}
