
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ConvertibleGroup("AudioPlay")]
	[ActionDescription("Plays the clip at a specific time on the absolute time-line that AudioSettings.ds" +
		"pTime reads from.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.PlayScheduled.html")]
	public sealed class AudioSourcePlayScheduled : BaseAction
	{
		
		[Tooltip("The AudioSource.")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Time in seconds on the absolute time-line that AudioSettings.dspTime refers to fo" +
			"r when the sound should start playing.")]
		[SerializeField]
		private DoubleVar _time;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _time);
		}
		
		public override void Execute()
		{
			//UnityEngine.AudioSource.PlayScheduled(System.Double);
			_audioSource.Value.PlayScheduled(_time.Value);
		}
		
		public override string GetSummary()
		{
			return "Play {_audioSource} at scheduled time {_time}";
		}
	}
}
