
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The interval in seconds from the last frame to the current one (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-deltaTime.html")]
	public sealed class TimeGetDeltaTime : BaseAction
	{
		
		[Tooltip("Get Time Delta Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getDeltaTime;

		[Tooltip("Optional multiplier to apply to the delta time.")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _multiplier;
		
		public override bool CanExecute() => CheckParameters(_getDeltaTime, _multiplier);

		public override void Execute() => _getDeltaTime.Value = Time.deltaTime * _multiplier.Value;

		public override string GetSummary() => 
			"Get delta time -> {_getDeltaTime}"
			+ (!Mathf.Approximately(_multiplier.Value, 1f) ? " * {_multiplier}" : "");
	}
}
