
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
	public sealed class TimeGetMaximumDeltaTime : BaseAction
	{
		
		[Tooltip("Get Time Maximum Delta Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getMaximumDeltaTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getMaximumDeltaTime);
		}
		
		public override void Execute()
		{
			_getMaximumDeltaTime.Value = Time.maximumDeltaTime;
		}
		
		public override string GetSummary()
		{
			return "Get maximum delta time -> {_getMaximumDeltaTime}";
		}
	}
}
