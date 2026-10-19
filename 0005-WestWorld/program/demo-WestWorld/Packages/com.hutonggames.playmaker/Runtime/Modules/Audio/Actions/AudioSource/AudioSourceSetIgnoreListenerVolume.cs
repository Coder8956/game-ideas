
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("This makes the audio source not take into account the volume of the audio listene" +
		"r.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-ignoreListenerVolume.html")]
	public sealed class AudioSourceSetIgnoreListenerVolume : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Ignore Listener Volume")]
		[SerializeField]
		private BoolVar _setIgnoreListenerVolume;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setIgnoreListenerVolume);
		}
		
		public override void Execute()
		{
			_audioSource.Value.ignoreListenerVolume = _setIgnoreListenerVolume.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} ignore listener volume to {_setIgnoreListenerVolume}";
		}
	}
}
