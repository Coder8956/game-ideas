
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The time at which the current MonoBehaviour.FixedUpdate started in seconds since " +
		"the start of the game (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-fixedTime.html")]
	public sealed class TimeGetFixedTime : BaseAction
	{
		
		[Tooltip("Get Time Fixed Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFixedTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getFixedTime);
		}
		
		public override void Execute()
		{
			_getFixedTime.Value = Time.fixedTime;
		}
		
		public override string GetSummary()
		{
			return "Get fixed time -> {_getFixedTime}";
		}
	}
}
