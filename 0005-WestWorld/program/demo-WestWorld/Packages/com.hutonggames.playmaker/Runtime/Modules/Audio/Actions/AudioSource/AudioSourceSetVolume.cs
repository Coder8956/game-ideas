
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("The volume of the audio source (0.0 to 1.0).")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-volume.html")]
	public sealed class AudioSourceSetVolume : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Volume")]
		[SerializeField]
		private FloatVar _setVolume;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setVolume);
		}
		
		public override void Execute()
		{
			_audioSource.Value.volume = _setVolume.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} volume to {_setVolume}";
		}
	}
}
