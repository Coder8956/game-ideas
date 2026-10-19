
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("The pitch of the audio source.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-pitch.html")]
	public sealed class AudioSourceSetPitch : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Pitch")]
		[SerializeField]
		private FloatVar _setPitch;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setPitch);
		}
		
		public override void Execute()
		{
			_audioSource.Value.pitch = _setPitch.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} pitch to {_setPitch}";
		}
	}
}
