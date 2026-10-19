
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioMixer)]
	[ActionDescription("Routing target.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Audio.AudioMixer-outputAudioMixerGroup.h" +
		"tml")]
	public sealed class AudioMixerGetOutputAudioMixerGroup : BaseAction
	{
		
		[Tooltip("The AudioMixer")]
		[SerializeField]
		private AudioMixerVar _audioMixer;
		
		[Tooltip("Get AudioMixer Output Audio Mixer Group")]
		[SerializeField]
		[WriteOnly]
		private AudioMixerGroupRef _getOutputAudioMixerGroup;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixer, _getOutputAudioMixerGroup);
		}
		
		public override void Execute()
		{
			_getOutputAudioMixerGroup.Value = _audioMixer.Value.outputAudioMixerGroup;
		}
		
		public override string GetSummary()
		{
			return "Get {_audioMixer} outputAudioMixerGroup -> {_getOutputAudioMixerGroup}";
		}
	}
}
