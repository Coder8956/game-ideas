
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
	public sealed class TimeSetCaptureFramerate : BaseAction
	{
		
		[Tooltip("Set Time Capture Framerate")]
		[SerializeField]
		private IntegerVar _setCaptureFramerate;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setCaptureFramerate);
		}
		
		public override void Execute()
		{
			Time.captureFramerate = _setCaptureFramerate.Value;
		}
		
		public override string GetSummary()
		{
			return "Set time capture framerate to {_setCaptureFramerate}";
		}
	}
}
