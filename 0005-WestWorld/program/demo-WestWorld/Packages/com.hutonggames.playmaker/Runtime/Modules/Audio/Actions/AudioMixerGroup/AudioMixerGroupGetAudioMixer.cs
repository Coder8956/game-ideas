using JetBrains.Annotations;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioMixerGroup)]
	[ActionDescription("Get the AudioMixer that the group is assigned to.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Audio.AudioMixerGroup-audioMixer.html")]
	public sealed class AudioMixerGroupGetAudioMixer : BaseAction
	{
		
		[Tooltip("The AudioMixerGroup")]
		[SerializeField]
		private AudioMixerGroupVar _audioMixerGroup;
		
		[Tooltip("Get AudioMixerGroup Audio Mixer")]
		[SerializeField]
		[WriteOnly]
		private AudioMixerRef _getAudioMixer;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixerGroup, _getAudioMixer);
		}
		
		public override void Execute()
		{
			_getAudioMixer.Value = _audioMixerGroup.Value.audioMixer;
		}
		
		public override string GetSummary()
		{
			return "Get {_audioMixerGroup} audioMixer -> {_getAudioMixer}";
		}
	}
}
