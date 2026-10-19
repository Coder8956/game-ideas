
using JetBrains.Annotations;
using UnityEngine;


namespace HutongGames.PlayMaker.Actions.Audio
{
	
	
	[System.Serializable]
	[PublicAPI]
	[ActionCategory(Category.AudioSource)]
	[ActionDescription("Sets/Gets how the AudioSource attenuates over distance.")]
	[HelpURL("https://docs.unity3d.com/ScriptReference/AudioSource-rolloffMode.html")]
	public sealed class AudioSourceSetRolloffMode : BaseAction
	{
		
		[Tooltip("The AudioSource")]
		[SerializeField]
		private AudioSourceVar _audioSource;
		
		[Tooltip("Set AudioSource Rolloff Mode")]
		[SerializeField]
		private AudioRolloffModeVar _setRolloffMode;
		
		public override bool CanExecute()
		{
			return CheckParameters(_audioSource, _setRolloffMode);
		}
		
		public override void Execute()
		{
			_audioSource.Value.rolloffMode = _setRolloffMode.Value;
		}
		
		public override string GetSummary()
		{
			return "Set {_audioSource} rolloff mode to {_setRolloffMode}";
		}
	}
}
