
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("Get how long the state has been active in seconds.")]
	public sealed class TimeGetTimeInState : BaseAction
	{
		
		[Tooltip("Get Time in current state in seconds.")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTimeInState;
		
		public override bool CanExecute() => CheckParameters(_getTimeInState);

		public override void Execute() => _getTimeInState.Value = State.ActiveTime;

		public override string GetSummary() => "Get time in state -> {_getTimeInState}";
	}
}
