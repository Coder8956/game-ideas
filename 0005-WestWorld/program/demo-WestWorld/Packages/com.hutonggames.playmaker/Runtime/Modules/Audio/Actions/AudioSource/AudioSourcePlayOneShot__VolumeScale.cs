
using JetBrains.Annotations;
using System;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ConvertibleGroup("AudioPlay")]
	[ActionDescription("Plays an AudioClip, and scales the AudioSource volume by volumeScale.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource.PlayOneShot.html")]
	public sealed class AudioSourcePlayOneShot__VolumeScale : BaseAction
	{
		
		[Tooltip("The AudioSource.")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("The clip being played.")]
		[SerializeField]
		private AudioClipVar _clip;
		
		[Tooltip("The scale of the volume (0-1).")]
		[SerializeField, DefaultValue(1f)]
		private FloatVar _volumeScale;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _clip, _volumeScale);
		}
		
		public override void Execute()
		{
			//UnityEngine.AudioSource.PlayOneShot(UnityEngine.AudioClip, System.Single);
			_audioSource.Value.PlayOneShot(_clip.Value, _volumeScale.Value);
		}
		
		public override string GetSummary()
		{
			return "Play {_clip} on {_audioSource} (volume: {_volumeScale})";
		}
	}
}
