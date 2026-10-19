
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The interval in seconds of timeScale-independent (\"real\") time at which physics and " +
		"other fixed frame rate updates (like MonoBehaviour\'s MonoBehaviour.FixedUpdate) " +
		"are performed.(Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-fixedUnscaledDeltaTime.html")]
	public sealed class TimeGetFixedUnscaledDeltaTime : BaseAction
	{
		
		[Tooltip("Get Time Fixed Unscaled Delta Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFixedUnscaledDeltaTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getFixedUnscaledDeltaTime);
		}
		
		public override void Execute()
		{
			_getFixedUnscaledDeltaTime.Value = Time.fixedUnscaledDeltaTime;
		}
		
		public override string GetSummary()
		{
			return "Get fixed unscaled delta time -> {_getFixedUnscaledDeltaTime}";
		}
	}
}
