
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Changes the time at which a sound that has already been scheduled to play will st" +
		"art.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.SetScheduledStartTime.html")]
	public sealed class AudioSourceSetScheduledStartTime : BaseAction
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
			//UnityEngine.AudioSource.SetScheduledStartTime(System.Double);
			_audioSource.Value.SetScheduledStartTime(_time.Value);
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} scheduled start time to {_time}";
		}
	}
}
