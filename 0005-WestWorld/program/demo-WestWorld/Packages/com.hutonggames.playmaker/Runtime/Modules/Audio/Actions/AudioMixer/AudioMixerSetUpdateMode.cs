
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioMixer)]
	[ActionDescription("How time should progress for this AudioMixer. Used during Snapshot transitions.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/Audio.AudioMixer-updateMode.html")]
	public sealed class AudioMixerSetUpdateMode : BaseAction
	{
		
		[Tooltip("The AudioMixer")]
		[SerializeField]
		private AudioMixerVar _audioMixer;
		
		[Tooltip("Set AudioMixer Update Mode")]
		[SerializeField]
		private AudioMixerUpdateModeVar _setUpdateMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixer, _setUpdateMode);
		}
		
		public override void Execute()
		{
			_audioMixer.Value.updateMode = _setUpdateMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioMixer} Update Mode to {_setUpdateMode}";
		}
	}
}
