
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The time in seconds since the last non-additive scene finished loading (Read Only).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-timeSinceLevelLoad.html")]
	public sealed class TimeGetTimeSinceLevelLoad : BaseAction
	{
		
		[Tooltip("Get Time Time Since Level Load")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getTimeSinceLevelLoad;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getTimeSinceLevelLoad);
		}
		
		public override void Execute()
		{
			_getTimeSinceLevelLoad.Value = Time.timeSinceLevelLoad;
		}
		
		public override string GetSummary()
		{
			return "Get time since level load -> {_getTimeSinceLevelLoad}";
		}
	}
}
