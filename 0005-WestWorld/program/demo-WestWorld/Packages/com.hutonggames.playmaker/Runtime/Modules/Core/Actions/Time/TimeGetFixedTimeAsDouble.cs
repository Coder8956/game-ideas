
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The double precision time since the last MonoBehaviour.FixedUpdate started (Read " +
		"Only). This is the time in seconds since the start of the game.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-fixedTimeAsDouble.html")]
	public sealed class TimeGetFixedTimeAsDouble : BaseAction
	{
		
		[Tooltip("Get Time Fixed Time As Double")]
		[SerializeField]
		[WriteOnly]
		private DoubleRef _getFixedTimeAsDouble;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getFixedTimeAsDouble);
		}
		
		public override void Execute()
		{
			_getFixedTimeAsDouble.Value = Time.fixedTimeAsDouble;
		}
		
		public override string GetSummary()
		{
			return "Get fixed time -> {_getFixedTimeAsDouble}";
		}
	}
}
