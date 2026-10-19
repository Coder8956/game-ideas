
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Playback position in PCM samples.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-timeSamples.html")]
	public sealed class AudioSourceSetTimeSamples : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Time Samples")]
		[SerializeField]
		private IntegerVar _setTimeSamples;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setTimeSamples);
		}
		
		public override void Execute()
		{
			_audioSource.Value.timeSamples = _setTimeSamples.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} time samples to {_setTimeSamples}";
		}
	}
}
