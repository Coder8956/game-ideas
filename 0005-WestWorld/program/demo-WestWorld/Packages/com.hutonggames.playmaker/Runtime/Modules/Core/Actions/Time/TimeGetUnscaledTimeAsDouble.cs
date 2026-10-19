
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The double precision timeScale-independent time for this frame (Read Only). This " +
		"is the time in seconds since the start of the game.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-unscaledTimeAsDouble.html")]
	public sealed class TimeGetUnscaledTimeAsDouble : BaseAction
	{
		
		[Tooltip("Get Time Unscaled Time As Double")]
		[SerializeField]
		[WriteOnly]
		private DoubleRef _getUnscaledTimeAsDouble;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getUnscaledTimeAsDouble);
		}
		
		public override void Execute()
		{
			_getUnscaledTimeAsDouble.Value = Time.unscaledTimeAsDouble;
		}
		
		public override string GetSummary()
		{
			return "Get unscaled time -> {_getUnscaledTimeAsDouble}";
		}
	}
}
