
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The timeScale-independent interval in seconds from the last frame to the current " +
		"one (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-unscaledDeltaTime.html")]
	public sealed class TimeGetUnscaledDeltaTime : BaseAction
	{
		
		[Tooltip("Get Time Unscaled Delta Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getUnscaledDeltaTime;
		
		[Tooltip("Optional multiplier to apply to the delta time.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _multiplier;
		
		public override bool CanExecute() => CheckParameters(_getUnscaledDeltaTime, _multiplier);

		public override void Execute() => _getUnscaledDeltaTime.Value = Time.unscaledDeltaTime * _multiplier.Value;

		public override string GetSummary() =>
			"Get unscaled delta time -> {_getUnscaledDeltaTime}"
			+ (!Mathf.Approximately(_multiplier.Value, 1f) ? " * {_multiplier}" : "");
	}
}
