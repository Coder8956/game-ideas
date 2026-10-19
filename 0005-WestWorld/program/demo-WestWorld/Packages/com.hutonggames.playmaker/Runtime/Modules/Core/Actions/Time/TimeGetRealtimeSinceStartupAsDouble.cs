
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The real time in seconds since the game started (Read Only). Double precision ver" +
		"sion of Time.realtimeSinceStartup.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-realtimeSinceStartupAsDouble.html")]
	public sealed class TimeGetRealtimeSinceStartupAsDouble : BaseAction
	{
		
		[Tooltip("Get Time Realtime Since Startup As Double")]
		[SerializeField]
		[WriteOnly]
		private DoubleRef _getRealtimeSinceStartupAsDouble;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getRealtimeSinceStartupAsDouble);
		}
		
		public override void Execute()
		{
			_getRealtimeSinceStartupAsDouble.Value = TimeHelper.RealtimeSinceStartupAsDouble;
		}
		
		public override string GetSummary()
		{
			return "Get realtime since startup -> {_getRealtimeSinceStartupAsDouble}";
		}
	}
}
