
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
	public sealed class AudioMixerGetUpdateMode : BaseAction
	{
		
		[Tooltip("The AudioMixer")]
		[SerializeField]
		private AudioMixerVar _audioMixer;
		
		[Tooltip("Get AudioMixer Update Mode")]
		[SerializeField]
		[WriteOnly]
		private AudioMixerUpdateModeRef _getUpdateMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioMixer, _getUpdateMode);
		}
		
		public override void Execute()
		{
			_getUpdateMode.Value = _audioMixer.Value.updateMode;
		}
		
		public override string GetSummary()
		{
			return "Get {_audioMixer} updateMode -> {_getUpdateMode}";
		}
	}
}
