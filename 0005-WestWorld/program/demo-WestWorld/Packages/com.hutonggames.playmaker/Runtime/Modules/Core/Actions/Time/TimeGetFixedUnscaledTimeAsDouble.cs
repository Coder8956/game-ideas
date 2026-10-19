
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The double precision timeScale-independent time at the beginning of the last Mono" +
		"Behaviour.FixedUpdate (Read Only). This is the time in seconds since the start o" +
		"f the game.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-fixedUnscaledTimeAsDouble.html")]
	public sealed class TimeGetFixedUnscaledTimeAsDouble : BaseAction
	{
		
		[Tooltip("Get Time Fixed Unscaled Time As Double")]
		[SerializeField]
		[WriteOnly]
		private DoubleRef _getFixedUnscaledTimeAsDouble;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getFixedUnscaledTimeAsDouble);
		}
		
		public override void Execute()
		{
			_getFixedUnscaledTimeAsDouble.Value = Time.fixedUnscaledTimeAsDouble;
		}
		
		public override string GetSummary()
		{
			return "Get fixed unscaled time -> {_getFixedUnscaledTimeAsDouble}";
		}
	}
}
