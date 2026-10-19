
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("The target group to which the AudioSource should route its signal.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-outputAudioMixerGroup.html")]
	public sealed class AudioSourceSetOutputAudioMixerGroup : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Output Audio Mixer Group")]
		[SerializeField, CanBeNullOrEmpty]
		private AudioMixerGroupVar _setOutputAudioMixerGroup;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource);
		}
		
		public override void Execute()
		{
			_audioSource.Value.outputAudioMixerGroup = _setOutputAudioMixerGroup.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} output audio mixer group to {_setOutputAudioMixerGroup}";
		}
	}
}
