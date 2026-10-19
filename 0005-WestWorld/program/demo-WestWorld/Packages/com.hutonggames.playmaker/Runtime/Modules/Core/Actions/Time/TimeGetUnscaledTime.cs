
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The timeScale-independent time for this frame (Read Only). This is the time in se" +
		"conds since the start of the game.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-unscaledTime.html")]
	public sealed class TimeGetUnscaledTime : BaseAction
	{
		
		[Tooltip("Get Time Unscaled Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getUnscaledTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getUnscaledTime);
		}
		
		public override void Execute()
		{
			_getUnscaledTime.Value = Time.unscaledTime;
		}
		
		public override string GetSummary()
		{
			return "Get unscaled time -> {_getUnscaledTime}";
		}
	}
}
