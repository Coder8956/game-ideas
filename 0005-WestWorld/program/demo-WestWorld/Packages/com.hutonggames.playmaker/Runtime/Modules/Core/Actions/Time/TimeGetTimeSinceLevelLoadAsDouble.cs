
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The double precision time in seconds since the last non-additive scene finished l" +
		"oading (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-timeSinceLevelLoadAsDouble.html")]
	public sealed class TimeGetTimeSinceLevelLoadAsDouble : BaseAction
	{
		
		[Tooltip("Get Time Time Since Level Load As Double")]
		[SerializeField]
		[WriteOnly]
		private DoubleRef _getTimeSinceLevelLoadAsDouble;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getTimeSinceLevelLoadAsDouble);
		}
		
		public override void Execute()
		{
			_getTimeSinceLevelLoadAsDouble.Value = Time.timeSinceLevelLoadAsDouble;
		}
		
		public override string GetSummary()
		{
			return "Get time since level load -> {_getTimeSinceLevelLoadAsDouble}";
		}
	}
}
