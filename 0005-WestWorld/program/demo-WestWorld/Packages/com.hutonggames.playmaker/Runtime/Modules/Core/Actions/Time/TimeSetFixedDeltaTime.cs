
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The interval in seconds of in-game time at which physics and other fixed frame ra" +
		"te updates (like MonoBehaviour\'s MonoBehaviour.FixedUpdate) are performed.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-fixedDeltaTime.html")]
	public sealed class TimeSetFixedDeltaTime : BaseAction
	{
		
		[Tooltip("Set Time Fixed Delta Time")]
		[SerializeField]
		private FloatVar _setFixedDeltaTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setFixedDeltaTime);
		}
		
		public override void Execute()
		{
			Time.fixedDeltaTime = _setFixedDeltaTime.Value;
		}
		
		public override string GetSummary()
		{
			return "Set time fixed delta time to {_setFixedDeltaTime}";
		}
	}
}
