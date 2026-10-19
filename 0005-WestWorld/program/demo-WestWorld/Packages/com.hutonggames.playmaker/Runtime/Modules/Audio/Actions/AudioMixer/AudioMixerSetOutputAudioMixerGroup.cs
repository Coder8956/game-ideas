
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
	public sealed class AudioMixerSetOutputAudioMixerGroup : BaseAction
	{
		
		[Tooltip("The AudioMixer")]
		[SerializeField]
		private AudioMixerVar _audioMixer;
		
		[Tooltip("Set AudioMixer Output Audio Mixer Group")]
		[SerializeField, CanBeNullOrEmpty]
		private AudioMixerGroupVar _setOutputAudioMixerGroup;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixer);
		}
		
		public override void Execute()
		{
			_audioMixer.Value.outputAudioMixerGroup = _setOutputAudioMixerGroup.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioMixer} Output Audio Mixer Group to {_setOutputAudioMixerGroup}";
		}
	}
}
