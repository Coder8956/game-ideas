
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The double precision time at the beginning of this frame (Read Only). This is the" +
		" time in seconds since the start of the game.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-timeAsDouble.html")]
	public sealed class TimeGetTimeAsDouble : BaseAction
	{
		
		[Tooltip("Get Time Time As Double")]
		[SerializeField]
		[WriteOnly]
		private DoubleRef _getTimeAsDouble;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getTimeAsDouble);
		}
		
		public override void Execute()
		{
			_getTimeAsDouble.Value = Time.timeAsDouble;
		}
		
		public override string GetSummary()
		{
			return "Get time -> {_getTimeAsDouble}";
		}
	}
}
