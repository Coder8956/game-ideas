
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("The reciprocal of Time.captureDeltaTime.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-captureFramerate.html")]
	public sealed class TimeGetCaptureFramerate : BaseAction
	{
		
		[Tooltip("Get Time Capture Framerate")]
		[SerializeField]
		[WriteOnly]
		private IntegerRef _getCaptureFramerate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getCaptureFramerate);
		}
		
		public override void Execute()
		{
			_getCaptureFramerate.Value = Time.captureFramerate;
		}
		
		public override string GetSummary()
		{
			return "Get capture framerate -> {_getCaptureFramerate}";
		}
	}
}
