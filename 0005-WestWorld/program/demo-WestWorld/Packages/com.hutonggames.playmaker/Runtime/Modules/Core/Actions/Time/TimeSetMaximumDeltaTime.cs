
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The maximum value of Time.deltaTime in any given frame. This is a time in seconds" +
		" that limits the increase of Time.time between two frames.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-maximumDeltaTime.html")]
	public sealed class TimeSetMaximumDeltaTime : BaseAction
	{
		
		[Tooltip("Set Time Maximum Delta Time")]
		[SerializeField]
		private FloatVar _setMaximumDeltaTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setMaximumDeltaTime);
		}
		
		public override void Execute()
		{
			Time.maximumDeltaTime = _setMaximumDeltaTime.Value;
		}
		
		public override string GetSummary()
		{
			return "Set time maximum delta time to {_setMaximumDeltaTime}";
		}
	}
}
