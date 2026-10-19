
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
	public sealed class TimeGetCaptureDeltaTime : BaseAction
	{
		
		[Tooltip("Get Time Capture Delta Time")]
		[SerializeField]
		[WriteOnly]
		private FloatRef _getCaptureDeltaTime;
		
		public override bool CanExecute()
		{
			return CheckParameters(_getCaptureDeltaTime);
		}
		
		public override void Execute()
		{
			_getCaptureDeltaTime.Value = Time.captureDeltaTime;
		}
		
		public override string GetSummary()
		{
			return "Get capture delta time -> {_getCaptureDeltaTime}";
		}
	}
}
