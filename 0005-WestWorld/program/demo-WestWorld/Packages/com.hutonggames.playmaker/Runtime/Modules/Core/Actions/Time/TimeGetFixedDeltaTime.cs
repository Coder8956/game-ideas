
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The interval in seconds of in-game time at which physics and other fixed frame rate " +
		"updates (like MonoBehaviour\'s MonoBehaviour.FixedUpdate) are performed.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-fixedDeltaTime.html")]
	public sealed class TimeGetFixedDeltaTime : BaseAction
	{
		
		[Tooltip("Get Time Fixed Delta Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getFixedDeltaTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getFixedDeltaTime);
		}
		
		public override void Execute()
		{
			_getFixedDeltaTime.Value = Time.fixedDeltaTime;
		}
		
		public override string GetSummary()
		{
			return "Get fixed delta time -> {_getFixedDeltaTime}";
		}
	}
}
