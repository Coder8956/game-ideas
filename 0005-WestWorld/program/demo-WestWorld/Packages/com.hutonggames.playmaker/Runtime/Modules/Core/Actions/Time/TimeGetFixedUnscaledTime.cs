
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The timeScale-independent time at the beginning of the last MonoBehaviour.FixedUpdate " +
		"phase (Read Only). This is the time in seconds since the start of the game.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-fixedUnscaledTime.html")]
	public sealed class TimeGetFixedUnscaledTime : BaseAction
	{
		
		[Tooltip("Get Time Fixed Unscaled Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFixedUnscaledTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getFixedUnscaledTime);
		}
		
		public override void Execute()
		{
			_getFixedUnscaledTime.Value = Time.fixedUnscaledTime;
		}
		
		public override string GetSummary()
		{
			return "Get fixed unscaled time -> {_getFixedUnscaledTime}";
		}
	}
}
