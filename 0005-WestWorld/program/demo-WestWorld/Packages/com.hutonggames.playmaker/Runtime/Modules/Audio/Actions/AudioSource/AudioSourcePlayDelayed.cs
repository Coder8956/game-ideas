
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ConvertibleGroup("AudioPlay")]
	[ActionDescription("Plays the clip with a delay specified in seconds. Users are advised to use this f" +
		"unction instead of the old Play(delay) function that took a delay specified in s" +
		"amples relative to a reference rate of 44.1 kHz as an argument.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.PlayDelayed.html")]
	public sealed class AudioSourcePlayDelayed : BaseAction
	{
		
		[Tooltip("The AudioSource.")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Delay time specified in seconds.")]
		[SerializeField]
		private FloatVar _delay;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _delay);
		}
		
		public override void Execute()
		{
			//UnityEngine.AudioSource.PlayDelayed(System.Single);
			_audioSource.Value.PlayDelayed(_delay.Value);
		}
		
		public override string GetSummary()
		{
			return "Play {_audioSource} after {_delay}";
		}
	}
}
