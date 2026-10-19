
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Changes the time at which a sound that has already been scheduled to play will en" +
		"d. Notice that depending on the timing not all rescheduling requests can be fulf" +
		"illed.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.SetScheduledEndTime.html")]
	public sealed class AudioSourceSetScheduledEndTime : BaseAction
	{
		
		[Tooltip("The AudioSource.")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Time in seconds.")]
		[SerializeField]
		private DoubleVar _time;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _time);
		}
		
		public override void Execute()
		{
			//UnityEngine.AudioSource.SetScheduledEndTime(System.Double);
			_audioSource.Value.SetScheduledEndTime(_time.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} scheduled end time to {_time}";
		}
	}
}
