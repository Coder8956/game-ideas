
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioMixerSnapshot)]
	[ActionDescription("Get the AudioMixer that the snapshot is assigned to.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Audio.AudioMixerSnapshot.html")]
	public sealed class AudioMixerSnapshotGetAudioMixer : BaseAction
	{
		
		[Tooltip("The AudioMixerSnapshot")]
		[SerializeField]
		private AudioMixerSnapshotVar _audioMixerSnapshot;
		
		[Tooltip("Get AudioMixerSnapshot Audio Mixer")]
		[SerializeField]
		[WriteOnly]
		private AudioMixerRef _getAudioMixer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixerSnapshot, _getAudioMixer);
		}
		
		public override void Execute()
		{
			_getAudioMixer.Value = _audioMixerSnapshot.Value.audioMixer;
		}
		
		public override string GetSummary()
		{
			return "Get {_audioMixerSnapshot} audioMixer -> {_getAudioMixer}";
		}
	}
}


