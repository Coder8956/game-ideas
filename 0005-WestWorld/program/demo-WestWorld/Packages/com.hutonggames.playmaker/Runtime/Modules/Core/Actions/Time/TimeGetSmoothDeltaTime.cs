
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("A smoothed out Time.deltaTime (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-smoothDeltaTime.html")]
	public sealed class TimeGetSmoothDeltaTime : BaseAction
	{
		
		[Tooltip("Get Time Smooth Delta Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getSmoothDeltaTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getSmoothDeltaTime);
		}
		
		public override void Execute()
		{
			_getSmoothDeltaTime.Value = Time.smoothDeltaTime;
		}
		
		public override string GetSummary()
		{
			return "Get smooth delta time -> {_getSmoothDeltaTime}";
		}
	}
}
