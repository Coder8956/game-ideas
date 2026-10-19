
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The time at the beginning of the current frame in seconds since the start of the " +
		"application (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-time.html")]
	public sealed class TimeGetTime : BaseAction
	{
		
		[Tooltip("Get Time Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getTime);
		}
		
		public override void Execute()
		{
			_getTime.Value = Time.time;
		}
		
		public override string GetSummary()
		{
			return "Get time -> {_getTime}";
		}
	}
}
