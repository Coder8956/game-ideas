
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.TimeUnity)]
	[ActionDescription("Slows your application’s playback time to allow Unity to save screenshots in between frames.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Time-captureDeltaTime.html")]
	public sealed class TimeSetCaptureDeltaTime : BaseAction
	{
		
		[Tooltip("Set Time Capture Delta Time")]
		[SerializeField]
		private FloatVar _setCaptureDeltaTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_setCaptureDeltaTime);
		}
		
		public override void Execute()
		{
			Time.captureDeltaTime = _setCaptureDeltaTime.Value;
		}
		
		public override string GetSummary()
		{
			return "Set time capture delta time to {_setCaptureDeltaTime}";
		}
	}
}
